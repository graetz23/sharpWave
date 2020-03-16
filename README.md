## sharpWave
### A _pragmatic_ port of [JWave](https://github.com/graetz23/JWave) to C#

### Introduction
[JWave](https://github.com/graetz23/JWave) was ported to [sharpWave](https://github.com/graetz23/sharpWave) using Microsoft's C# programming language.

### HowTo
For a _some_ how to use it; [JWave's github.io](http://graetz23.github.io/JWave/)

### building
For having a quick example, use _GNU/Linux_ having the _mono compiler_
available. Then try:

**git clone https://github.com/graetz23/sharpWave.git && cd sharpWave && make run**

### remarks
The following functionality is available:
- **1-D, 2-D, and 3-D** orthogonal **transform algorithms**; _class BasicTransform_:
  - **Fast Wavelet Transform (FWT)**; _class FastWaveletTransform_,  
  - (Fast) **Wavelet Packet Transform (WPT)**; _class WaveletPacketTransform_,
  - Some **Shifting Wavelet Transform (SWT)**; _class ShiftingWaveletTransform_,
  - **Discrete Fourier Transform (DFT)**; _class Discrete Fourier Transform_.
- Orthogonal and in most cases orthonormal wavelets:
  - Orthonormal **Haar Wavelet**; _class Haar1_.

**have fun :-)**

## ChangeLog

### 20200316
- ported the Discrete Fourier Transform (DFT),
- ported the _some_ Shifting Wavelet Transform (SWT),
- ported the (Fast) Wavelet Packet Transform (WPT); Wavelet Packet Decomposition (WPD),
- extended the _class SharpWave_ for testing the SWT algorithm.
- extended the _class SharpWave_ for testing the WPT / WPD algorithm.

### 20200315
- ported _getter_ methods to C#'s _lambda_ style
- reconstructed the Constructors of _Transform_ classes,
- decided to use _C#'s multidimensional_ instead of _jagged_ arrays,
- added 2-D forward and reverse (stepping) algorithms,
- added 3-D forward and reverse (stepping) algorithms,
- extended the main method by 2-D example,
- recycled comments towards C#'s XML style,
- cleaned code.

### 20200314
- added 1-D orthogonal transform functions,
- added the Fast Wavelet Transform algorithms,
- added the orthonormal Haar Wavelet.

### 20200304
- started the ported,
- ported all necessary classes for a minimal example.
