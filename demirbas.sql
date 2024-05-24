-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 24 May 2024, 10:53:12
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `demirbas`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `donanim`
--

CREATE TABLE `donanim` (
  `id` int(11) NOT NULL,
  `marka` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `aciklama` varchar(50) NOT NULL,
  `verildigiTarih` date NOT NULL,
  `kullanici_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `donanim`
--

INSERT INTO `donanim` (`id`, `marka`, `model`, `aciklama`, `verildigiTarih`, `kullanici_id`) VALUES
(1, 'Apple ', 'Mac Studio M2 Ultra', 'Kasa', '2024-01-01', 1),
(2, 'Apple', '27\'\'', 'Monitör', '2024-01-01', 1),
(3, 'Razer', 'Blackwidow v4 Pro', 'Klavye', '2024-01-01', 1),
(4, 'Razer', 'Deathadder v3 Pro', 'Kablosuz Mouse', '2024-01-01', 1),
(5, 'Samsung', 'S23 Ultra', 'Telefon', '2024-01-02', 2),
(6, 'Dell', 'Precision T5860', 'Kasa', '2024-01-02', 3),
(7, 'LG', '27\'\'', 'Monitör', '2024-01-02', 3),
(8, 'Dell', 'Precision T5860', 'Kasa', '2024-01-02', 4),
(9, 'LG', '27\'\'', 'Monitör', '2024-01-02', 4),
(10, 'HP', 'Pro', 'Kasa', '2024-01-03', 5),
(11, 'LG', '27\'\'', 'Monitör', '2024-01-03', 5),
(12, 'Samsung', 'S23 Ultra', 'Telefon', '2024-01-03', 6);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kasa`
--

CREATE TABLE `kasa` (
  `id` int(11) NOT NULL,
  `demirbas_no` varchar(10) NOT NULL,
  `isletim_sistemi` varchar(50) NOT NULL,
  `islemci_model` varchar(50) NOT NULL,
  `ram` varchar(10) NOT NULL,
  `disk_kapasite` varchar(10) NOT NULL,
  `ekran_karti` varchar(50) NOT NULL,
  `model` varchar(50) NOT NULL,
  `islemci_hizi` varchar(10) NOT NULL,
  `cekirdek_sayisi` varchar(10) NOT NULL,
  `ekran_boyut` varchar(10) NOT NULL,
  `urun_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `kasa`
--

INSERT INTO `kasa` (`id`, `demirbas_no`, `isletim_sistemi`, `islemci_model`, `ram`, `disk_kapasite`, `ekran_karti`, `model`, `islemci_hizi`, `cekirdek_sayisi`, `ekran_boyut`, `urun_id`) VALUES
(1, 'K1001', 'Macos', 'M2', '64', '2048', 'Paylaşımlı', 'Mac Pro', '16', '4', 'N/A', 1),
(2, 'K1002', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 'Studio Display', 'N/A', 'N/A', '27\'\'', 2),
(3, 'K1003', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 'Blackwidow v4 Pro', 'N/A', 'N/A', 'N/A', 3),
(4, 'K1004', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 'Deathadder v3 Pro', 'N/A', 'N/A', 'N/A', 4),
(5, 'K1005', 'Andorid', 'Adreno (Snapdragon 8 Gen 2)', '8', '256', 'N/A', 'S23 Ultra', '3', '3', '5.9\'\'', 5),
(6, 'K1006', 'Windows 11', 'Intel® Xeon® w5-2445', 'N/A', '2048', 'NVIDIA® RTX™ A4000, 16 GB GDDR6', 'T5860', '4', '10', 'N/A', 6),
(7, 'K1007', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', '27GP850-B', 'N/A', 'N/A', '27\'\'', 0),
(8, 'K1008', 'Windows 11', 'Intel® Xeon® w5-2445', 'N/A', '2048', 'NVIDIA® RTX™ A4000, 16 GB GDDR6', 'T5860', '4', '10', 'N/A', 0),
(9, 'K1009', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', '27GP850-B', 'N/A', 'N/A', '27\'\'', 0),
(10, 'K1010', 'Windows 11', 'i7 13400', '32', '2048', 'Tümleşik', 'Pro', '4', '8', 'N/A', 0),
(11, 'K1011', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', '27GP850-B', 'N/A', 'N/A', '27\'\'', 0),
(12, 'K1012', 'Andorid', 'Adreno (Snapdragon 8 Gen 2)', '8', '256', 'N/A', 'S23 Ultra', '3', '3', '5.9\'\'', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `personel`
--

CREATE TABLE `personel` (
  `id` int(10) NOT NULL,
  `ad` varchar(50) NOT NULL,
  `soyad` varchar(50) NOT NULL,
  `sicil_no` int(10) NOT NULL,
  `unvan` varchar(50) NOT NULL,
  `bolum` varchar(50) NOT NULL,
  `eposta` varchar(50) NOT NULL,
  `sifre` varchar(50) NOT NULL,
  `oda_numarasi` int(11) NOT NULL,
  `baslama_tarihi` date NOT NULL,
  `resim` varchar(50) NOT NULL,
  `notlar` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `personel`
--

INSERT INTO `personel` (`id`, `ad`, `soyad`, `sicil_no`, `unvan`, `bolum`, `eposta`, `sifre`, `oda_numarasi`, `baslama_tarihi`, `resim`, `notlar`) VALUES
(1, 'Deniz', 'Güngör', 100, 'Yönetici', 'Bilgisayar Mühendisliği', 'deniz@mail.com', 'deniz123', 1, '2024-01-01', 'uploads/deniz_resim.jpg', 'Deniz bu şirketi 01.01.2024 tarihinde kurmuştur. İşe alımlardan sadece Deniz Güngör sorumludur.'),
(2, 'Yusuf', 'Çimen', 101, 'Temizlikci', 'Bilgisayar Mühendisliği', 'yusuf@mail.com', 'yusuf123', 2, '2024-01-02', 'uploads/yusuf_resim.jpg', 'Yusuf şirkette temizlik görevlisi olarak iş yapmakta ve kendisine bir adet S23 ultra tahsil edilmiştir.'),
(3, 'Samet', 'Gök', 102, 'Programcı', 'Bilgisayar Mühendisliği', 'samet@mail.com', 'samet123', 3, '2024-01-02', 'uploads/samet_resim.jpg', 'Galatasaraylı bu sene şampiyon oldukları için mutlu umarım tekrar 13. olmazlar.'),
(4, 'Emir', 'Yüksel', 103, 'Programcı', 'Bilgisayar Mühendisliği', 'emir@mail.com', 'emir123', 4, '2024-01-02', 'uploads/emir_resim.jpg', 'Galatasaray her hafta kaybedecek demekten yorulmuyor.Ayrıca başı Temizlikçi ile belada.'),
(5, 'Onur', 'Gül', 104, 'Danışman', 'Fizik Mühendisliği', 'onur@mail.com', 'onur123', 5, '2024-01-03', '', 'Onur danışman olarak görev yapmakta.'),
(6, 'Çağdaş', 'Şimşek', 105, 'Güvenlik', 'İşletme', 'cagdas@mail.com', 'cagdas123', 65, '2024-01-03', 'iVBORw0KGgoAAAANSUhEUgAAAQAAAAEACAYAAABccqhmAAAAAX', 'Çağdaş güvenlik olarak görev yapmakta');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `donanim`
--
ALTER TABLE `donanim`
  ADD PRIMARY KEY (`id`,`kullanici_id`);

--
-- Tablo için indeksler `kasa`
--
ALTER TABLE `kasa`
  ADD PRIMARY KEY (`id`,`demirbas_no`,`urun_id`);

--
-- Tablo için indeksler `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `sicil_no_2` (`sicil_no`),
  ADD UNIQUE KEY `sicil_no_3` (`sicil_no`),
  ADD KEY `sicil_no` (`sicil_no`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `donanim`
--
ALTER TABLE `donanim`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- Tablo için AUTO_INCREMENT değeri `kasa`
--
ALTER TABLE `kasa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- Tablo için AUTO_INCREMENT değeri `personel`
--
ALTER TABLE `personel`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
