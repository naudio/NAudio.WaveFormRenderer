# NAudio.WaveFormRenderer
Simple utility to render waveforms of audio files to PNGs. Uses [NAudio](https://github.com/naudio/naudio) to extract the peaks and `System.Drawing` to render the images.

The project contains the `WaveFormRendererLib` library which performs peak calculation and waveform rendering, along with a simple test harness WinForms application to try it out with different settings. This can be used in any project that is able to take a dependency on NAudio and System.Drawing. It can be used in WinForms or WPF apps, or within ASP.NET applications to generate server side waveform images.

The waveform rendering algorithm is customizable:

 * Supports several peak calculation strategies (max, average, sampled, RMS, decibels)
 * Supports different colors or gradients for the top and bottom half
 * Supports different sizes for top and bottom half
 * Overall image size and background can be customized
 * Transparent backgrounds
 * Support for SoundCloud style bars
 * Several built-in rendering styles

## Breaking changes

v2 switches from passing in a filename to passing in a NAudio `WaveStream`. This allows it to be used cross-platform without taking a dependency on `AudioFileReader` which is Windows only. On Windows, simply use `AudioFileReader` to create the `WaveStream`. On other platforms you can still use `WaveFileReader`, or `Mp3FileReader` using the NLayer frame decoder.

## Test Harness Application
Test harness app makes it easy to experiment with the various rendering options and save the results as a PNG.
![Test Harness UI](https://cloud.githubusercontent.com/assets/147668/18606773/48335280-7cb1-11e6-9d91-a69ea31395a6.PNG)

## Example Waveforms

Basic solid color waveform
![Basic solid color](https://cloud.githubusercontent.com/assets/147668/18606780/60f30ed2-7cb1-11e6-823b-40b67995eff6.png)

Gradient vertical bars (old SoundCloud style)
![Gradient vertical bars](https://cloud.githubusercontent.com/assets/147668/18606779/5de210da-7cb1-11e6-96e2-bfab242ae3d1.png)

Blocks (SoundCloud style)
![Blocks](https://cloud.githubusercontent.com/assets/147668/18606777/55f732c4-7cb1-11e6-93bd-c35980687d7b.png)

![Orange Blocks](https://cloud.githubusercontent.com/assets/147668/18606778/5a9516ac-7cb1-11e6-8660-a0a80d72fe26.png)

Transparent Backgrounds
![Transparent Background](https://cloud.githubusercontent.com/assets/147668/18606781/6482e9c8-7cb1-11e6-864f-5e5e910953c7.png)

![Transparent Background](https://cloud.githubusercontent.com/assets/147668/18606782/689b9046-7cb1-11e6-8f1f-b68aefa32b95.png)
