function obj = audio(SampleRate,NumChannels,ID)
    frameLength = 1024;
    deviceReader = audioDeviceReader;
    fileWriter = dsp.AudioFileWriter('output.wav','SampleRate',deviceReader.SampleRate);
    deviceWriter = audioDeviceWriter('SampleRate',deviceReader.SampleRate);
    fileReader = dsp.AudioFileReader('output.wav');
    process = @(x) x.*5;
    disp('start')
    tic
    while 1
        mySignal = deviceReader();
        %mySignal = fileReader();
        myProcessedSignal = process(mySignal);
        %deviceWriter(myProcessedSignal);
        fileWriter(myProcessedSignal);
        %deviceWriter(fileReader());
       % tic
        if(toc > 1)
            mySignal = fileReader();
            myProcessedSignal = process(mySignal);
            deviceWriter(myProcessedSignal);
        end
%         mySignal = fileReader();
%         myProcessedSignal = process(mySignal);
%         deviceWriter(myProcessedSignal);
    end
%     while ~isDone(fileReader)
%         mySignal = fileReader();
%         myProcessedSignal = process(mySignal);
%         deviceWriter(myProcessedSignal);
%     end
    disp('end')
    release(deviceReader)
    release(deviceWriter)
    release(fileWriter)
end

