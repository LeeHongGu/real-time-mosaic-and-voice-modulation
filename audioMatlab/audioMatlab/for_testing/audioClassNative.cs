/*
* MATLAB Compiler: 8.2 (R2021a)
* Date: Sat May  8 18:32:38 2021
* Arguments:
* "-B""macro_default""-W""dotnet:audioMatlab,audioClass,4.0,private,version=1.0""-T""link:
* lib""-d""C:\Users\thkim\OneDrive\????\MATLAB\audioMatlab\for_testing""-v""class{audioCla
* ss:C:\Users\thkim\OneDrive\????\MATLAB\audio.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace audioMatlabNative
{

  /// <summary>
  /// The audioClass class provides a CLS compliant, Object (native) interface to the
  /// MATLAB functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\thkim\OneDrive\¹®¼­\MATLAB\audio.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class audioClass : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static audioClass()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "audioMatlab.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the audioClass class.
    /// </summary>
    public audioClass()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~audioClass()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object audio()
    {
      return mcr.EvaluateFunction("audio", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="SampleRate">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object audio(Object SampleRate)
    {
      return mcr.EvaluateFunction("audio", SampleRate);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="SampleRate">Input argument #1</param>
    /// <param name="NumChannels">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object audio(Object SampleRate, Object NumChannels)
    {
      return mcr.EvaluateFunction("audio", SampleRate, NumChannels);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="SampleRate">Input argument #1</param>
    /// <param name="NumChannels">Input argument #2</param>
    /// <param name="ID">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object audio(Object SampleRate, Object NumChannels, Object ID)
    {
      return mcr.EvaluateFunction("audio", SampleRate, NumChannels, ID);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] audio(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "audio", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="SampleRate">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] audio(int numArgsOut, Object SampleRate)
    {
      return mcr.EvaluateFunction(numArgsOut, "audio", SampleRate);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="SampleRate">Input argument #1</param>
    /// <param name="NumChannels">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] audio(int numArgsOut, Object SampleRate, Object NumChannels)
    {
      return mcr.EvaluateFunction(numArgsOut, "audio", SampleRate, NumChannels);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the audio MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="SampleRate">Input argument #1</param>
    /// <param name="NumChannels">Input argument #2</param>
    /// <param name="ID">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] audio(int numArgsOut, Object SampleRate, Object NumChannels, Object 
                    ID)
    {
      return mcr.EvaluateFunction(numArgsOut, "audio", SampleRate, NumChannels, ID);
    }


    /// <summary>
    /// Provides an interface for the audio function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("audio", 3, 1, 0)]
    protected void audio(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("audio", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
