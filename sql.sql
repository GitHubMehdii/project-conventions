-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 31, 2019 at 08:21 AM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `conventions`
--

-- --------------------------------------------------------

--
-- Table structure for table `conventions`
--

CREATE TABLE `conventions` (
  `id` int(11) NOT NULL,
  `apogee` int(11) NOT NULL,
  `startDate` varchar(30) NOT NULL,
  `endDate` varchar(30) NOT NULL,
  `companyName` varchar(30) NOT NULL,
  `city` varchar(30) NOT NULL,
  `comments` varchar(250) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `conventions`
--
ALTER TABLE `conventions`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `conventions`
--
ALTER TABLE `conventions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
