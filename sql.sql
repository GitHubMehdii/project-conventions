-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 31, 2019 at 05:39 AM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `conventions`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Apogee` int(11) NOT NULL,
  `BirthDate` varchar(30) NOT NULL,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Filiere` varchar(30) NOT NULL,
  `Year` varchar(30) NOT NULL,
  `About` varchar(250) NOT NULL,
  `isAdmin` varchar(5) NOT NULL DEFAULT 'no' COMMENT 'yes | no'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Apogee`, `BirthDate`, `FirstName`, `LastName`, `Email`, `Filiere`, `Year`, `About`, `isAdmin`) VALUES
(12345678, '1995-01-01', 'Mehdi', 'Chaoui', 'mehdi.mc60@gmail.com', 'GI', '3', 'About me', 'no');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `apogee` (`Apogee`);
