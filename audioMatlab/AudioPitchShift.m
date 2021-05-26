function pitchshift(shift_val)
    
    % Create test bench input and output
    deviceReader = audioDeviceReader;
    deviceWriter = audioDeviceWriter('SampleRate',deviceReader.SampleRate);

    % Set up the system under test
    sut = audiopluginexample.PitchShifter;
    setSampleRate(sut,deviceReader.SampleRate);
    sut.PitchShift = shift_val;

    % Open parameterTuner for interactive tuning during simulation
%     tuner = parameterTuner(sut);
%     drawnow

    % Stream processing loop
%    while 1
    nOverruns = 0;
    nUnderruns = 0;
    maxIterations = 10000;
    for iter = 1:maxIterations
        % Read from input, process, and write to output
        [in,novr] = deviceReader();
        nOverruns = nOverruns + novr;   % Increment the overrun counter
        in = repmat(in,1,2);
        out = sut(in);
        nUnderruns = nUnderruns + deviceWriter(out);

        % Process parameterTuner callbacks
%             drawnow limitrate
    end
%     nOverruns = 0;
%     nUnderruns = 0;
%     maxIterations = 0;
%    disp('초기화')
%    end

    % Clean up
    release(sut)
    release(deviceReader)
    release(deviceWriter)
end

