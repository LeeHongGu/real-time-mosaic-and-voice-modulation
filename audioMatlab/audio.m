function obj = audio()
    deviceReader = audioDeviceReader;
    fileWriter = dsp.AudioFileWriter('output.wav','SampleRate',deviceReader.SampleRate);
    deviceWriter = audioDeviceWriter('SampleRate',deviceReader.SampleRate);
    %fileReader = dsp.AudioFileReader('output.wav');
    process = @(x) x.*5;
    disp('start')
    
    while 1
        mySignal = deviceReader();
        myProcessedSignal = process(mySignal);
        deviceWriter(myProcessedSignal);
        fileWriter(myProcessedSignal); 
    end
    
    disp('end')
    release(deviceReader)
    release(deviceWriter)
    release(fileWriter)
end

