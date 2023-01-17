-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 17 Oca 2023, 13:35:56
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `emlakuygulamasi`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `property_client`
--

CREATE TABLE `property_client` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(200) NOT NULL,
  `address` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `property_client`
--

INSERT INTO `property_client` (`id`, `first_name`, `last_name`, `phone`, `email`, `address`) VALUES
(1, 'mehmet', 'yuce', '5463636', 'mehmet@hotmail.com', 'fdshrtjs sdhdsj'),
(6, 'musa', 'uzunlar', '546357357', 'sfhdfn@hotmail.com', 'dgjdgrkgdrkfmgdfm');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `property_owner`
--

CREATE TABLE `property_owner` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(200) NOT NULL,
  `address` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `property_owner`
--

INSERT INTO `property_owner` (`id`, `first_name`, `last_name`, `phone`, `email`, `address`) VALUES
(1, 'ahmet', 'turk', '54363473557', 'satici@hotmail.com', 'sadghsfhdsnsd'),
(2, 'Oguzhan', 'Yuce', '543634626', 'oguzhan@hotmail.com', 'kutahya merkez '),
(5, 'sedat', 'erik', '436534637', 'kahtehe@hotmail.com', 'hdfjndsgmm'),
(6, 'hasan', 'kara', '435436', 'hasan@gmail.com', 'sdfhfnjdshfddf');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `property_type`
--

CREATE TABLE `property_type` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `property_type`
--

INSERT INTO `property_type` (`id`, `name`, `description`) VALUES
(5, 'Rezidans', 'Ev/Apartman'),
(7, 'Reklam', 'Magaza / is yeri'),
(8, 'Endustriyel', 'Fabrika veya diger endustriyel calisma yerleri'),
(9, 'Arsa', 'Sadece arsa');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `the_property`
--

CREATE TABLE `the_property` (
  `id` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `square_feet` int(20) NOT NULL,
  `ownerid` int(11) NOT NULL,
  `price` varchar(20) NOT NULL,
  `address` text NOT NULL,
  `bedrooms` int(4) NOT NULL,
  `bathrooms` int(4) NOT NULL,
  `age` int(5) NOT NULL,
  `balcony` tinyint(1) NOT NULL,
  `backyard` tinyint(1) NOT NULL,
  `pool` tinyint(1) NOT NULL,
  `garage` tinyint(1) NOT NULL,
  `fireplace` tinyint(1) NOT NULL,
  `comment` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `the_property`
--

INSERT INTO `the_property` (`id`, `type`, `square_feet`, `ownerid`, `price`, `address`, `bedrooms`, `bathrooms`, `age`, `balcony`, `backyard`, `pool`, `garage`, `fireplace`, `comment`) VALUES
(1, 0, 0, 0, '', '', 0, 0, 0, 0, 0, 0, 0, 0, ''),
(2, 7, 500, 1, '7000', 'burada', 6, 2, 3, 1, 1, 0, 1, 1, 'yorum');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'user', '12345'),
(2, 'admin', 'abcd'),
(4, 'admin', 'abcd'),
(5, 'csharp', 'pass');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `property_client`
--
ALTER TABLE `property_client`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `property_owner`
--
ALTER TABLE `property_owner`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `property_type`
--
ALTER TABLE `property_type`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `the_property`
--
ALTER TABLE `the_property`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `property_client`
--
ALTER TABLE `property_client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `property_owner`
--
ALTER TABLE `property_owner`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `property_type`
--
ALTER TABLE `property_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `the_property`
--
ALTER TABLE `the_property`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
