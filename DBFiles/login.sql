-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 30, 2016 at 02:29 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 5.5.37

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `login`
--

-- --------------------------------------------------------

--
-- Table structure for table `businfo`
--

CREATE TABLE `businfo` (
  `code` int(11) NOT NULL,
  `seat` int(11) NOT NULL,
  `departing` varchar(50) NOT NULL,
  `arival` varchar(50) NOT NULL,
  `ticketfare` int(11) NOT NULL,
  `startcounter` varchar(50) NOT NULL,
  `endcounter` varchar(50) NOT NULL,
  `avaiable` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `businfo`
--

INSERT INTO `businfo` (`code`, `seat`, `departing`, `arival`, `ticketfare`, `startcounter`, `endcounter`, `avaiable`) VALUES
(12, 30, '00:00', '06:30', 450, 'Rajshahi', 'Dhaka', 1),
(13, 25, '00:00', '06:00', 450, 'Rajshahi', 'Sylhet', 1),
(14, 30, '00:00', '06:00', 450, 'Rajshahi', 'Jessore', 1),
(15, 30, '00:00', '06:00', 450, 'Dhaka', 'Jessore', 1),
(16, 30, '00:00', '06:00', 450, 'Dhaka', 'Chittagong', 1),
(17, 30, '06:00', '12:00', 450, 'Rajshahi', 'Chittagong', 1),
(18, 30, '00:00', '06:00', 450, 'Dhaka', 'Sylhet', 1),
(19, 30, '00:00', '06:00', 450, 'Sylhet', 'Dhaka', 1),
(20, 30, '03:00', '09:00', 450, 'Rajshahi', 'Dhaka', 1),
(21, 30, '05:00', '11:00', 450, 'Khulna', 'Dhaka', 1),
(22, 30, '05:00', '11:00', 450, 'Rajshahi', 'Dhaka', 1),
(23, 30, '01:00', '07:00', 450, 'Rajshahi', 'Dhaka', 1),
(24, 30, '00:00', '06:00', 450, 'Dhaka', 'Khulna', 1),
(25, 30, '00:00', '06:00', 450, 'Dhaka', 'Sylhet', 1);

-- --------------------------------------------------------

--
-- Table structure for table `userinfo`
--

CREATE TABLE `userinfo` (
  `username` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userinfo`
--

INSERT INTO `userinfo` (`username`, `first_name`, `last_name`, `phone`, `email`) VALUES
('abc', 'tanvir', 'islam', '49622620', 'tanvieer@gmail.com'),
('abcr', 'tanvir', 'islam', '49622620', 'tanvir@gmail.com'),
('fjda', 'mobasser ahmed', 'ahmed', '016767423', 'moba@gmail.com'),
('admin', 'Admin', 'Shaheb', '01911066421', 'asjdfn@gmail.com'),
('nnn', 'slkdf', 'r', '49622620', 'en94joy@gmail.com'),
('tanvieer', 'tanvir', 'islam', '01911066421', 'sanvieer@gmail.com'),
('ta', 'tljla', 'sldkfnsd', '65465', 'kj@gmail.com'),
('aaaaaaaaaaaaa', 'mehedi', 'r', '01911066421', 'en94joy@gmail.comdd');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `admin` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`username`, `password`, `admin`) VALUES
('aaaaaaaaaaaaa', 'abc', 0),
('abc', 'abc', 0),
('abcr', 'abc', 0),
('admin', 'admin', 1),
('fjda', '123', 0),
('nnn', 'abc', 0),
('ta', 'ta', 0),
('tanvieer', '123', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `businfo`
--
ALTER TABLE `businfo`
  ADD PRIMARY KEY (`code`);

--
-- Indexes for table `userinfo`
--
ALTER TABLE `userinfo`
  ADD KEY `username` (`username`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`username`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `businfo`
--
ALTER TABLE `businfo`
  MODIFY `code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
