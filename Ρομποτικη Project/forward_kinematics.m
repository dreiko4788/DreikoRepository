function[T10, T20, T30, T40] = forward_kinematics(l1, l2, l3, qx, qy, qz, theta1, theta2)

% Pinakas peristrofhs ths bashs (SS{1}) ws pros ton a3ona x tou SS{0}
R1x0 = [1 0 0
		0 cosd(qx) -sind(qx)
		0 sind(qx) cosd(qx)];

% Pinakas peristrofhs ths bashs (SS{1}) ws pros ton a3ona y tou SS{0}	
R1y0 = [cosd(qy) 0 sind(qy)
		0 1 0
		-sind(qy) 0 cosd(qy)];

% Pinakas peristrofhs ths bashs (SS{1}) ws pros ton a3ona z tou SS{0}	
R1z0 = [cosd(qz) -sind(qz) 0
		sind(qz) cosd(qz) 0
		0 0 1];

% Oloklhrwmenos pinakas peristrofhs ths bashs (SS{1}) ws pros to SS{0}		
R10 = R1x0*R1y0*R1z0;

% Omogenhs metasxhmatismos ths bashs (SS{1}) ws pros to SS{0}
T10 = [R10(1,1) R10(1,2) R10(1,3) 0
		R10(2,1) R10(2,2) R10(2,3) 0
		R10(3,1) R10(3,2) R10(3,3) 0
		0 0 0 1];

% Omogenhs metasxhmatismos ths 2hs ar8rwshs (SS{2}) ws pros to SS{1}		
T21 = [cosd(theta1) -sind(theta1) 0 l1
		sind(theta1) cosd(theta1) 0 0
		0 0 1 0
		0 0 0 1];

% Omogenhs metasxhmatismos ths 3hs ar8rwshs (SS{3}) ws pros to SS{2}	
T32 = [cosd(theta2) -sind(theta2) 0 l2
		sind(theta2) cosd(theta2) 0 0
		0 0 1 0
		0 0 0 1];

% Omogenhs metasxhmatismos tou TSD (SS{4}) ws pros to SS{3}
T43 = [1 0 0 l3
		0 1 0 0
		0 0 1 0
		0 0 0 1];

% Upologismos metasxhmatismwm ws pros to SS{0}
T20 = T10*T21; % 2h ar8rwsh	
T30 = T20*T32; % 3h ar8rwsh
T40 = T10*T21*T32*T43; % TSD