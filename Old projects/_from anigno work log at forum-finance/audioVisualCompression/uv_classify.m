function type = uv_classify(signal,fixed_signal)
% This function determines whether the signal is voiced or unvoiced
% If it's voiced the function returns type = 1, else, type = 0.
% We'll first determine if the block contains a signal by calculating the short time energy and then decide if
% the signal is unvoiced or voiced.
epsilon = 1e-5;
N = length(signal);

energy = sum( signal(64 : 191).^2 );  % Calculating short time energy.
if (energy < epsilon) % The block doesn't contain speech signal.
    type = 0;
else % If at least two of the four conditions occur, the signal is unvoiced.
    cnt = 0;
    zero_crosses = zero_cross(signal);
    if (zero_crosses > N/2) % zero crosses more than 128 ?
        cnt = cnt + 1;
    end 
    if energy < 0.01 * max(abs(signal)) % energy below 1 percent of the power value of the signal
        cnt = cnt + 1;
    end 
    
    % The auto-correlation local max is not a legal pitch value.
    % The pitch should be between 50-400 Hz.
    MAX_SAMPLE = 160; % correlates to 50 Hz.
    MIN_SAMPLE = 20; % correlates to 400 Hz.
    R = xcorr(fixed_signal); % Cutting the non positive values of k (including zero).
        
    Rk = R(N+1:end); % 1<=k<=N-1.
    % create 3 shifted versions of the sample (no shift, left shift, right
    % shift)
    R_l = [Rk; 0; 0];
    R_m = [0 ;Rk; 0];
    R_r = [0 ;0 ;Rk];
    % find the locations of the local maximas (higher then right and left
    % samples)
    LocalMax = (R_m > R_l) + (R_m > R_r);
    LocalMax = LocalMax( 2 : N ) == 2;
    Rk = Rk .* LocalMax;
    % finding the highest local maximum
    [m pitch] = max(Rk); 
    
    if ((pitch > MAX_SAMPLE) || (pitch < MIN_SAMPLE))
        cnt = cnt + 1;
    end     % Is the energy of the largest local maximum ratio is less then 0.35
    fixed_energy = R(N); % the value at zero.
    if( m < 0.35 * R(N) )
        cnt = cnt + 1;
    end

    if(cnt >=2)
        type = 0;
    else
        type = 1;
    end
end