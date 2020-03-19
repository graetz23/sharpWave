## sharpWave
### A _refactored_ port of [JWave](https://github.com/graetz23/JWave) to C#

### Introduction
[JWave](https://github.com/graetz23/JWave) was ported to [sharpWave](https://github.com/graetz23/sharpWave) using Microsoft's C# programming language.

### HowTo
For _some_ how to use it; [JWave's github.io](http://graetz23.github.io/JWave/)

### building
For having a quick example, use _GNU/Linux_ having the _mono compiler_
available. Then try:

**git clone https://github.com/graetz23/sharpWave.git && cd sharpWave && make run**

### remarks
The following functionality is available:
- The **1-D, 2-D, and 3-D orthogonal transform algorithms**; [class Algorithm](https://github.com/graetz23/sharpWave/blob/master/Algorithm.cs):
  - a kind of **Fast Wavelet Transform (FWT)**; [class FastWaveletTransform](https://github.com/graetz23/sharpWave/blob/master/FastWaveletTransform.cs),  
  - a (Fast) **Wavelet Packet Transform (WPT)**; [class WaveletPacketTransform](https://github.com/graetz23/sharpWave/blob/master/WaveletPacketTransform.cs),
  - some **Shifting Wavelet Transform (SWT)**; [class ShiftingWaveletTransform](https://github.com/graetz23/sharpWave/blob/master/ShiftingWaveletTransform.cs),
  - and a **Discrete Fourier Transform (DFT)**; [class DiscreteFourierTransform](https://github.com/graetz23/sharpWave/blob/master/DiscreteFourierTransform.cs).
- Orthogonal and in most cases orthonormal wavelets:
  - **Orthonormal Haar Wavelet**; [class Haar1](https://github.com/graetz23/sharpWave/blob/master/Haar1.cs),
  - **Orthogonal Haar Wavelet**; [class Haar1Orthogonal](https://github.com/graetz23/sharpWave/blob/master/Haar1Orthogonal.cs),
  - **Orthonormal Coiflet 1 Wavelet**; [class Coiflet1](https://github.com/graetz23/sharpWave/blob/master/Coiflet1.cs),
  - **Orthonormal Coiflet 2 Wavelet**; [class Coiflet2](https://github.com/graetz23/sharpWave/blob/master/Coiflet2.cs); rounding error ~1e-10,
  - **Orthonormal Coiflet 3 Wavelet**; [class Coiflet3](https://github.com/graetz23/sharpWave/blob/master/Coiflet3.cs); rounding error ~1e-12,
  - **Orthonormal Coiflet 4 Wavelet**; [class Coiflet4](https://github.com/graetz23/sharpWave/blob/master/Coiflet4.cs); rounding error ~1e-10,
  - **Orthonormal Coiflet 5 Wavelet**; [class Coiflet5](https://github.com/graetz23/sharpWave/blob/master/Coiflet5.cs); rounding error ~1e-08,
  - **Orthonormal Legendre 1 Wavelet**; [class Legendre1](https://github.com/graetz23/sharpWave/blob/master/Legendre1.cs),
  - **Orthonormal Legendre 2 Wavelet**; [class Legendre2](https://github.com/graetz23/sharpWave/blob/master/Legendre2.cs); not working properly,
  - **Orthonormal Legendre 3 Wavelet**; [class Legendre3](https://github.com/graetz23/sharpWave/blob/master/Legendre3.cs); not working properly,
  - **Orthonormal Daubechies 2 Wavelet**; [class Daubechies2](https://github.com/graetz23/sharpWave/blob/master/Daubechies2.cs),
  - **Orthonormal Daubechies 3 Wavelet**; [class Daubechies3](https://github.com/graetz23/sharpWave/blob/master/Daubechies3.cs),
  - **Orthonormal Daubechies 4 Wavelet**; [class Daubechies4](https://github.com/graetz23/sharpWave/blob/master/Daubechies4.cs); rounding error ~1e-12,
  - **Orthonormal Symlet 2 Wavelet**; [class Symlet2](https://github.com/graetz23/sharpWave/blob/master/Symlet2.cs),
  - **Orthogonal Mallat's Battle 23**; [class Battle23](https://github.com/graetz23/sharpWave/blob/master/Battle23.cs); not working properly,
  - **Orthogonal Cohen Daubechies Feauveau (CDF) 5/3**; [class CDF53](https://github.com/graetz23/sharpWave/blob/master/CDF53.cs); not working properly,
  - **Orthogonal Cohen Daubechies Feauveau (CDF) 9/7**; [class CDF97](https://github.com/graetz23/sharpWave/blob/master/CDF97.cs); not working properly,
  - **Orthogonal Discrete Mayer Wavelet**; [class DiscreteMayer](https://github.com/graetz23/sharpWave/blob/master/DiscreteMayer.cs); strong rounding errors; ~1e-2,
- Everything was coded using
  - [atom](https://atom.io/) editor,
  - [mono](https://www.mono-project.com/) compiler,
  - [Gnome](https://www.gnome.org/) windows manager,
  - and [debian](https://www.debian.org/) GNU/Linux,

**have fun :-)**

## ChangeLog

### 20200319
- added the _Daubechies 3_ wavelet,
- added the _Daubechies 4_ wavelet,

### 20200318
- added the _Coiflet 2_ wavelet,
- added the _Coiflet 3_ wavelet,
- added the _Coiflet 4_ wavelet,
- added the _Coiflet 5_ wavelet,
- added the _Mallat's Battle 23_ wavelet,
- added the _Cohen Daubechies Feauveau (CDF) 5/3_ wavelet,
- added the _Cohen Daubechies Feauveau (CDF) 9/7_ wavelet.

### 20200317
- renamed class _BasicTransform_ to _Algorithm_,
- ported Alfred Haar's orthogonal wavelet:
  - extended the explanation of [orthogonality and orthonormality](https://github.com/graetz23/sharpWave/blob/master/Haar1Orthogonal.cs),
  - made the methods _forward_ and _reverse_ of _class Wavelet_ virtual.
- added the _Coiflet 1_ wavelet,
- added the _Legendre 1_ wavelet,
- added the _Legendre 2_ wavelet,
- added the _Legendre 3_ wavelet,
- added the _Daubechies 2_ wavelet,
- added the _Symlet 2_ wavelet.
- added the _DiscreteMayer_ wavelet.

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
