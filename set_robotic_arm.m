% Ka8arismos metablhtwn
clear variables;

% Kleisimo para8urwn
%close all;

% Mhkos ar8rwsewn
l = 0.5;

% Mhkh ar8rwsewn
l1 = l; % 1h ar8rwsh
l2 = l; % 2h ar8rwsh
l3 = l; % 3h ar8rwsh

% Gwnies peristrofhs ths bashs (SS{1}) ws pros x-y-z tou SS{0}
qx = 90; % O a3onas x tou SS{1} ka8etos ws pros ton a3ona x tou SS{0}, gia na einai or8ios o braxionas
qy = 0; % Peristrofh braxiona
qz = 90; % O a3onas z tou SS{1} ka8etos ws pros ton a3ona z tou SS{0}

% Gwnia peristrofhs ths 2hs ar8rwshs ws pros thn 1h
theta1 = 315;

% Gwnia peristrofhs ths 3hs ar8rwshs ws pros thn 2h
theta2 = 270;

% Dhmiourgia eu8eias kinhmatikhs
[T10, T20, T30, T40] = forward_kinematics(l1, l2, l3, qx, qy, qz, theta1, theta2);

% Grafikh anaparastash tou braxiona
plot3([0 T20(1,4)], [0 T20(2,4)], [0 T20(3,4)],...
[T20(1,4) T30(1,4)], [T20(2,4) T30(2,4)], [T20(3,4) T30(3,4)],...
[T30(1,4) T40(1,4)], [T30(2,4) T40(2,4)], [T30(3,4) T40(3,4)],...
'Marker', 'o', 'LineStyle', '-');

% Emfanish eswterikwn grammwn tou xwrou
grid;

% Onomata a3onwn
xlabel('X');
ylabel('Y');
zlabel('N');

% Suntetagmenes TSD
xe = T40(1,4);
ye = T40(2,4);
ze = T40(3,4);

% Ektupwsh suntetagmenwn TSD
fprintf('\n\tSuntetagmenes TSD eu8eias kinhmatikhs\nTSD(x, y, z) = TSD(%f, %f, %f)\n', xe, ye, ze);

% Paush gia na fanei h arxikh 8esh
pause(2);

% Suntetagmenes TSD gia thn kinhsh
dx = 0.75;
dy = 0.1;
dz = 0.65;

% Nea peristrofh braxiona
rot = 30;

% Ektupwsh suntetagmenwn TSD
fprintf('\n\tSuntetagmenes TSD gia thn kinhsh\nTSD(x, y, z) = TSD(%f, %f, %f)\n', dx, dy, dz);

% Dhmiourgia antistrofhs kinhmatikhs
[invtheta1, invtheta2] = inverse_kinematics(l1, l2, l3, dx, dy, dz);

% Ektupwsh gwniwn antistrofhs kinhmatikhs
fprintf('\n\tGwnies antistrofhs kinhmatikhs\ninvtheta1 = %f\ninvtheta2 = %f\n', invtheta1, invtheta2);

% Sxediasmos troxias braxiona
motion_planning(l1, l2, l3, qx, qy, qz, rot, theta1, theta2, invtheta1, invtheta2);

% Eu8eia diaforikh kinhmatikh
[J, K] = differential_kinematics(l1, l2, l3, theta1, theta2, invtheta1, invtheta2);

% Antistrofh diaforikh kinhmatikh    
I = (J^(-1))*K; % J^(-1) o antistrofos pinakas tou J