-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Време на генериране: 
-- Версия на сървъра: 5.5.32
-- Версия на PHP: 5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- БД: `supermarket`
--

-- --------------------------------------------------------

--
-- Структура на таблица `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `ProductId` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(45) NOT NULL,
  `ProductPrice` decimal(10,2) NOT NULL,
  `VendorId` int(11) NOT NULL,
  `MeasureId` int(11) NOT NULL,
  PRIMARY KEY (`ProductId`),
  UNIQUE KEY `ProductId_UNIQUE` (`ProductId`),
  KEY `fk_Products_Vendors_idx` (`VendorId`),
  KEY `fk_Products_Measurs1_idx` (`MeasureId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COMMENT='		' AUTO_INCREMENT=16 ;

--
-- Схема на данните от таблица `products`
--

INSERT INTO `products` (`ProductId`, `ProductName`, `ProductPrice`, `VendorId`, `MeasureId`) VALUES
(1, 'Zagorka Light', '1.25', 2, 1),
(2, 'Zagorka Dark', '1.15', 2, 1),
(3, 'Zagorka Fusion', '1.32', 2, 1),
(4, 'Zagorka Ultimate', '1.52', 2, 1),
(5, 'Zagorka For Men', '2.00', 2, 1),
(6, 'Kamenitsa Light', '1.14', 4, 1),
(7, 'Kamenitsa Dark', '1.50', 4, 1),
(8, 'Kamenitsa Special', '2.11', 4, 1),
(9, 'Kamenitsa For Men', '1.54', 4, 1),
(10, 'Kamenitsa Ultimate', '2.12', 4, 1),
(11, 'Dark Chocolate', '1.45', 1, 2),
(12, 'Milk Chocolate', '1.39', 1, 2),
(13, 'Milk Chocolate with Nuts', '1.87', 1, 2),
(14, 'Milk Chocolate 200', '2.83', 1, 2),
(15, 'Dark Chocolate 200', '3.12', 1, 2);

--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_Products_Measurs1` FOREIGN KEY (`MeasureId`) REFERENCES `measures` (`MeasureId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Products_Vendors` FOREIGN KEY (`VendorId`) REFERENCES `vendors` (`VendorId`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
