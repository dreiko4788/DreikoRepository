function motion_planning(l1, l2, l3, qx, qy, qz, rot, theta1, theta2, invtheta1, invtheta2)

% Euresh ths megaluterhs diaforas gwniwn (gia ari8mo epanalhyewn twn allagwn)
max = rot;
diff = rot;
if invtheta1 > theta1
	max = invtheta1;
	diff = abs(theta1-invtheta1);
end

if invtheta2 > theta2
	max = invtheta2;
	diff = abs(theta2-invtheta2);
end

fprintf('\n\t\t\tSxediasmos troxias\n');

% Allagh gwniwn
for r = 1:diff

	% Peristrofh braxiona
	if rot > 0
		qy = qy+1;
	elseif rot < 0
		qy = qy-1;
	end
		
	% Allagh gwnias theta1 (klish 2hs ar8rwshs)
	if theta1 < invtheta1
		theta1 = theta1+1;
	elseif theta1 > invtheta1
		theta1 = theta1-1;
	end
		
	% Allagh gwnias theta2 (klish 3hs ar8rwshs)
	if theta2 < invtheta2
		theta2 = theta2+1;
	elseif theta2 > invtheta2
		theta2 = theta2-1;
	end
	
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
	
	% Paush meta3u allagwn
	pause(0.05);
end

% Suntetagmenes TSD
xe = T40(1,4);
ye = T40(2,4);
ze = T40(3,4);

% Ektupwsh suntetagmenwn TSD
fprintf('\n\tSuntetagmenes TSD meta thn kinhsh\nTSD(x, y, z) = TSD(%f, %f, %f)\n', xe, ye, ze);