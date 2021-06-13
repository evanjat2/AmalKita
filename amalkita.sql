-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 13, 2021 at 06:45 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `amalkita`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1, 'Evan', 'Ananda Jati'),
(3, 'Annisa', 'Raihana');

-- --------------------------------------------------------

--
-- Table structure for table `article`
--

CREATE TABLE `article` (
  `ID` int(11) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Content` text NOT NULL,
  `Images` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `article`
--

INSERT INTO `article` (`ID`, `Title`, `Content`, `Images`) VALUES
(1, 'Tentang COVID-19', 'Apa itu COVID-19?\r\nPneumonia Coronavirus Disease 2019 atau COVID-19 adalah penyakit peradangan paru yang disebabkan oleh Severe Acute Respiratory Syndrome Coronavirus 2 (SARS-CoV-2). Gejala klinis yang muncul beragam, mulai dari seperti gejala flu biasa (batuk, pilek, nyeri tenggorok, nyeri otot, nyeri kepala) sampai yang berkomplikasi berat (pneumonia atau sepsis).\r\n\r\nBagaimana COVID-19 Menular?\r\nCara penularan COVID-19 ialah melalui kontak dengan droplet saluran napas penderita. Droplet merupakan partikel kecil dari mulut penderita yang mengandung kuman penyakit, yang dihasilkan pada saat batuk, bersin, atau berbicara. Droplet dapat melewati sampai jarak tertentu (biasanya 1 meter).', 0x89504e470d0a1a0a0000000d49484452000000240000001d0806000000c275cefd0000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa86400000038494441545847edcea10d002000c030fe3f98100c7cc02ca2a2be63ae7d7e2254848a50112a4245a80815a12254848a50112a4245e86d9f0b31ceeaee43be81b80000000049454e44ae426082),
(2, 'Tambah 7.465, Positif Corona di RI 12 Juni Tembus 1,9 Juta Kasus', 'Pemerintah melaporkan tambahan kasus positif Corona (COVID-19) hari ini sebanyak 7.465. Jadi total kasus positif COVID-19 sedari awal pandemi hingga saat ini mencapai 1.901.490.\r\nAngka tersebut berdasarkan data Kementerian Kesehatan (Kemenkes), yang disampaikan oleh Badan Nasional Penanggulangan Bencana (BNPB) kepada wartawan, Sabtu (12/6/2021). Data kasus Corona di RI diperbarui tiap pukul 12.00 WIB.\r\n\r\nKasus positif COVID-19 yang aktif hari ini jumlahnya meningkat 2.009 kasus. Angka ini lebih tinggi dibanding Jumat (11/6) yakni 1.660 kasus aktif COVID, total kasus aktif per hari ini adalah 108.324.', 0x89504e470d0a1a0a0000000d49484452000000240000001d0806000000c275cefd0000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa86400000038494441545847edcea10d002000c030fe3f98100c7cc02ca2a2be63ae7d7e2254848a50112a4245a80815a12254848a50112a4245e86d9f0b31ceeaee43be81b80000000049454e44ae426082),
(3, '5 Bencana Melanda Indonesia di Awal 2021', 'Lima bencana terjadi di Tanah Air di pembuka tahun 2021. Mulai dari jatuhnya pesawat Sriwijaya Air SJ182 pada 9 Januari 2020, disusul longsor Cimanggung, Sumedang yang hingga kini menelan puluhan korban jiwa.\r\nBerselang satu pekan kejadian gempa bumi berkekuatan M 6,2 juga menghantam Kabupaten Majene dan Mamuju, Sulawesi Barat, pada 15 Januari. BNPB merilis hingga saat ini (Minggu, 17 Januari), 56 orang meninggal dunia.\r\n\r\nBelum kering air mata, banjir bandang juga merendam Kalimantan Selatan. Basarnas mengungkap 2.600 warga yang terdampak harus mengungsi. Teranyar, banjir dan longsor juga terjadi di Kota Manado, 6 orang meninggal dunia dan 500 lebih warga yang terdampak mengungsi', 0x89504e470d0a1a0a0000000d49484452000000240000001d0806000000c275cefd0000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa86400000038494441545847edcea10d002000c030fe3f98100c7cc02ca2a2be63ae7d7e2254848a50112a4245a80815a12254848a50112a4245e86d9f0b31ceeaee43be81b80000000049454e44ae426082),
(4, 'Sembako Masuk Barang Kena Pajak, Stafsus Sri Mulyani: Tak Berarti Dikenai Pajak', 'Staf Khusus Menteri Keuangan Sri Mulyani Indrawati, Yustinus Prastowo, menjelaskan ihwal draf Revisi Undang-Undang Nomor 6 Tahun 1983 tentang Ketentuan Umum dan Tata Cara Perpajakan (KUP). Penjelasan ini disampaikan di antaranya merespons ramainya pemberitaan soal rencana pengenaan PPN Sembako belakangan ini. \r\n\r\nPrastowo menjelaskan, di Pasal 4A beleid tersebut, bahan kebutuhan pokok atau sembako akan dikeluarkan dari barang-barang yang dikecualikan dari pengenaan pajak pertambahan nilai atau PPN. Adanya revisi pasal tentang barang kena pajak atau BKP ini tak berarti membuat pemerintah serta-merta akan mengenakan tarif pajak untuk sembako.\r\n\r\nApalagi untuk bahan-bahan pokok yang dijual di pasar guna memenuhi kebutuhan hidup orang banyak. “Menjadi barang kena pajak tidak lantas berarti dia dikenai pajak,” ujar Prastowo dalam diskusi bersama Trijaya FM, Sabtu, 12 Juni 2021.', 0x89504e470d0a1a0a0000000d49484452000000240000001d0806000000c275cefd0000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa86400000038494441545847edcea10d002000c030fe3f98100c7cc02ca2a2be63ae7d7e2254848a50112a4245a80815a12254848a50112a4245e86d9f0b31ceeaee43be81b80000000049454e44ae426082);

-- --------------------------------------------------------

--
-- Table structure for table `donated`
--

CREATE TABLE `donated` (
  `ID` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `amount` int(11) NOT NULL,
  `destination` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donated`
--

INSERT INTO `donated` (`ID`, `username`, `amount`, `destination`) VALUES
(4, 'user1', 50000, 'Anonim A'),
(5, 'user2', 50000, 'Anonim C');

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `ID` int(11) NOT NULL,
  `Nama Penerima` varchar(50) NOT NULL,
  `Jenis Item` varchar(50) NOT NULL,
  `Harga Per Item` int(11) NOT NULL,
  `Target` int(50) NOT NULL,
  `Kurang` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donation`
--

INSERT INTO `donation` (`ID`, `Nama Penerima`, `Jenis Item`, `Harga Per Item`, `Target`, `Kurang`) VALUES
(11, 'Anonim A', 'Sembako', 10000, 5, 0),
(12, 'Anonim B', 'Perlengkapan Alat Tulis', 10000, 5, 5),
(13, 'Anonim C', 'Pakaian', 50000, 5, 2),
(14, 'Anonim D', 'Makanan', 5000, 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Email` text NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `saldo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `Nama`, `Email`, `username`, `password`, `saldo`) VALUES
(10, 'User 1', 'user1', 'user1', 'user1', 450000),
(11, 'user2', 'user2', 'user2', 'user2', 150000),
(12, 'q', 'q', 'q', 'q', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `donated`
--
ALTER TABLE `donated`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `donation`
--
ALTER TABLE `donation`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `article`
--
ALTER TABLE `article`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `donated`
--
ALTER TABLE `donated`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `donation`
--
ALTER TABLE `donation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
