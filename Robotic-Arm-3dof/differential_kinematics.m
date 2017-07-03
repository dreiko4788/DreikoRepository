function[J, K] = differential_kinematics(l1, l2, l3, theta1, theta2, invtheta1, invtheta2)

% Iakovianh (JA - gwniakes taxuthtes)
J = [( -(l2)*cosd(theta1)-(l3)*cosd(theta1+theta2) ) ( -(l3)*cosd(theta1+theta2) ) 
	( -(l2)*sind(theta1) -(l3)*sind(theta1+theta2) ) ( -(l3)*sind(theta1+theta2) )];
 
% Gwnies
difftheta1 = (invtheta1-theta1)/(2-0);
difftheta2 = (invtheta2-theta2)/(2-0);

% Oi 2 paragwgoi gwniwn
I = [difftheta1
	difftheta2];
 
% Telikos pinakas me tis taxuthtes
K = J*I;