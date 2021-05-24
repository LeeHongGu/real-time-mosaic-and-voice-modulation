function obj = audio(SampleRate,NumChannels,ID)
    %frameLength = 1024;
    deviceReader = audioDeviceReader;
    fileWriter = dsp.AudioFileWriter('output.wav','SampleRate',deviceReader.SampleRate);
    deviceWriter = audioDeviceWriter('SampleRate',deviceReader.SampleRate);
    fileReader = dsp.AudioFileReader('output.wav');
    process = @(x) x.*5;
    disp('start')
    
    while 1
        tic
        while toc < 5
            disp('start2')
            mySignal = deviceReader();
            %mySignal = fileReader();
            myProcessedSignal = process(mySignal);
            %deviceWriter(myProcessedSignal);
            fileWriter(myProcessedSignal);
            %deviceWriter(fileReader());
            % tic
        end
        
        while ~isDone(fileReader)
            disp('start3')
            mySignal = fileReader();
            myProcessedSignal = process(mySignal);
            deviceWriter(myProcessedSignal);
        end
%     while ~isDone(fileReader)
%         mySignal = fileReader();
%         myProcessedSignal = process(mySignal);
%         deviceWriter(myProcessedSignal);
%     end
    end
    disp('end')
    release(deviceReader)
    release(deviceWriter)
    release(fileWriter)
end

