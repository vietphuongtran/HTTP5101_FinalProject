-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 07, 2019 at 02:21 AM
-- Server version: 5.7.24-log
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dailybugle`
--

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `authorid` int(10) UNSIGNED NOT NULL,
  `authorfname` varchar(255) COLLATE latin1_bin DEFAULT NULL,
  `authorlname` varchar(255) COLLATE latin1_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`authorid`, `authorfname`, `authorlname`) VALUES
(1, 'Karen', 'Page'),
(2, 'Ben', 'Ulrich'),
(3, 'Christine', 'Everheart'),
(4, 'Pat', 'Kiernan'),
(5, 'Jonah', 'Jameson'),
(6, 'Griffin', 'Sinclair');

-- --------------------------------------------------------

--
-- Table structure for table `pages`
--

CREATE TABLE `pages` (
  `pageid` int(20) NOT NULL,
  `authorid` int(10) UNSIGNED DEFAULT NULL,
  `pagetitle` varchar(255) COLLATE latin1_bin DEFAULT NULL,
  `pagebody` mediumtext COLLATE latin1_bin
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `pages`
--

INSERT INTO `pages` (`pageid`, `authorid`, `pagetitle`, `pagebody`) VALUES
(2, 6, 'Is Iron Man really a hero as we know he is', 'An Alcoholic, a narcisist, stubborn is this the kind of characteristic from a hero? And yet, we worship the one who has all those flaws. Time to unravel the real devil behind the iron mask'),
(3, 4, 'Two Captain Americas spotted in Germany and New York', 'You did not read it wrong! While we all know that Captain Steve Roger is now in Germany trying to clean up the remnant of Hydra, our reporter has captured this photos showing he is jogging down the street of Brooklyn. How much lies is he hiding? Stay tuned!'),
(4, 3, 'Becareful of the money trap from Wakanda', 'King T\'Challa has generously given a huge pile of money to the USA without the demand to be repaid. Is it sound familiar like the Money Trap of China. Because it is!'),
(5, 2, 'The Blip brought back more than just human', 'As we all know, The Hulk or now Doctor Green heroicly wore the Iron Gaunlet and brought back half of the universe. However, it seem like his action comes with a side-effect. As there is a group of enhanced human claimed to have super ability granted by the power of the Blip. This autonomous group called themselves the X-men has been a constant headache for the local authority for the past few months'),
(6, 1, 'Why Sam Wilson should not be the new Captain America', 'The decision of who should be the next Captain America is not the one you should take lightly. It should be left to the people of America to decide. Although Sam is a great soldier but without any superpower, are the world going to be safer under his protection? What guarantee that he will not abuse his power while he always go with James Buchanan Barnes - the most wanted terrorist of America?'),
(18, 1, 'Bucky should be arrested', 'Why we let a criminal run freely on our street and call him a hero? Is it the kind of man you want a kid to grow up becoming? Arrest him now!');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`authorid`);

--
-- Indexes for table `pages`
--
ALTER TABLE `pages`
  ADD PRIMARY KEY (`pageid`),
  ADD KEY `authorid` (`authorid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `authorid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `pages`
--
ALTER TABLE `pages`
  MODIFY `pageid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
