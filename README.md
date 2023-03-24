# Tubes2_BikiniBot
## Tugas Besar 2 IF2211 Strategi Algoritma Semester II Tahun 2022/2023 Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt

## Kelompok : 
| Nama                      | NIM      |
|---------------------------|----------|
| Bintang Hijriawan Jacha             | 13521003 |
| Laila Bilbina Khoiru Nisa   | 13521016 |
| Kartini Copa     | 13521026 |

## Struktur Direktori
|---  `src` => *source code* dari program C#<br>
|---  `test` => input file txt untuk maze<br>
|---  `bin` => executable code / hasil build dari program C#<br>
|---  `doc` => file laporan<br>

## Algoritma BFS dan DFS dalam  Persoalan Maze Treasure Hunt

Program yang akan dibangun adalah sebuah aplikasi GUI sederhana dari Treasure Hunt Solver yang memanfaatkan algoritma Breadth-First Search (BFS) dan Depth-First Search (DFS) untuk mencari rute solusi dari sebuah maze yang berisi harta karun yang perlu ditemukan. Input untuk program ini adalah sebuah file txt yang berisi maze dengan batasan berbentuk segi-empat yang terdiri dari beberapa simbol, yaitu K (Krusty Krab) sebagai titik awal, T (Treasure) sebagai tujuan akhir, R (Grid yang mungkin diakses / sebuah lintasan), dan X (Grid halangan yang tidak dapat diakses).

Program ini memiliki GUI sederhana dengan beberapa fitur, yaitu:

1. Menerima input file maze treasure hunt atau nama file maze tersebut.
2. Memvalidasi file input apakah mengandung simbol yang valid (K, T, R, X) dan menampilkan visualisasi awal dari maze treasure hunt jika valid, atau memunculkan pesan error jika tidak valid.
3. Menggunakan toggle untuk memilih algoritma yang digunakan (BFS atau DFS).
4. Tombol "Search" untuk mengeksekusi pencarian rute solusi dengan algoritma yang dipilih, kemudian menampilkan rute solusi pada visualisasi maze treasure hunt.

## Cara Menjalankan Program
1. Jalankan MazeSolver.exe


## Requirement dan Instalasi
1. VS Code          (https://code.visualstudio.com/Download)
2. Visual Studio    (https://visualstudio.microsoft.com/downloads/)
3. .NET Framework   (https://dotnet.microsoft.com/en-us/download/dotnet-framework)
4. .NET SDK         (https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.202-windows-x64-installer?journey=vs-code)
