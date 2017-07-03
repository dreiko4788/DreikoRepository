function[invtheta1, invtheta2] = inverse_kinematics(l1, l2, l3, dx, dy, dz)

% Euresh gwnias theta2 (klish 3hs ar8rwshs)
c =( (dx^2+dy^2+(dz-l1)^2-l2^2-l3^2) / (2*l2*l3) ); % Sunhmitono gwnias
invtheta2 = round(360-acosd(c)); % Nea gwnia theta2

% Euresh gwnias theta1 (klish 2hs ar8rwshs)
a = acosd(c);
b = cosd(a);
f = atan2(dz-l2, sqrt(dx^2+dy^2));
x = atan2d(l2*sin(acos(c)), l2+l3*b);
invtheta1 = round(360-f-x); % Nea gwnia theta1