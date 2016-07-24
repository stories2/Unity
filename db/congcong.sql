-- phpMyAdmin SQL Dump
-- version 4.3.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- 생성 시간: 16-07-24 08:54
-- 서버 버전: 5.5.39-MariaDB
-- PHP 버전: 5.5.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 데이터베이스: `congcong`
--

-- --------------------------------------------------------

--
-- 테이블 구조 `friend`
--

CREATE TABLE IF NOT EXISTS `friend` (
  `PlayerId` int(11) DEFAULT '0',
  `FriendId` int(11) DEFAULT '0',
  `UpdateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Broke` tinyint(1) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `friend`
--

INSERT INTO `friend` (`PlayerId`, `FriendId`, `UpdateTime`, `Broke`) VALUES
(376, 430, '2016-07-22 11:38:48', 0),
(430, 376, '2016-07-21 10:13:33', 0),
(376, 441, '2016-07-21 10:13:33', 0),
(441, 376, '2016-07-21 10:13:33', 0),
(20, 376, '2016-07-24 03:00:01', 0),
(376, 20, '2016-07-24 03:00:01', 0),
(499, 376, '2016-07-24 03:31:17', 0),
(376, 499, '2016-07-24 03:31:17', 0),
(535, 499, '2016-07-24 08:34:04', 1),
(499, 535, '2016-07-24 07:52:07', 0),
(535, 499, '2016-07-24 08:34:04', 1),
(499, 535, '2016-07-24 07:54:29', 0),
(535, 499, '2016-07-24 08:34:04', 1),
(499, 535, '2016-07-24 08:00:05', 0),
(535, 20, '2016-07-24 08:11:29', 0),
(20, 535, '2016-07-24 08:11:29', 0),
(535, 499, '2016-07-24 08:34:04', 1),
(499, 535, '2016-07-24 08:20:02', 0),
(535, 499, '2016-07-24 08:34:20', 0),
(499, 535, '2016-07-24 08:34:20', 0);

-- --------------------------------------------------------

--
-- 테이블 구조 `rank`
--

CREATE TABLE IF NOT EXISTS `rank` (
  `PlayerId` int(11) NOT NULL,
  `Score` int(11) DEFAULT '0',
  `UpdateScoreTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `rank`
--

INSERT INTO `rank` (`PlayerId`, `Score`, `UpdateScoreTime`) VALUES
(20, 2, '2016-07-17 15:50:25'),
(376, 0, '2016-07-18 04:33:33'),
(499, 1, '2016-07-24 03:30:51'),
(501, 2, '2016-07-24 04:01:40'),
(527, 0, '2016-07-24 05:58:14'),
(528, 1, '2016-07-24 06:01:01'),
(534, 0, '2016-07-24 07:46:43'),
(535, 3, '2016-07-24 07:50:09'),
(557, 2, '2016-07-24 08:36:03');

-- --------------------------------------------------------

--
-- 테이블 구조 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `MacAddress` varchar(12) DEFAULT NULL,
  `PlayerId` int(11) NOT NULL,
  `InstallTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ConnectTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `EOGTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastPlayTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `FaceBookId` text
) ENGINE=InnoDB AUTO_INCREMENT=559 DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `user`
--

INSERT INTO `user` (`MacAddress`, `PlayerId`, `InstallTime`, `ConnectTime`, `EOGTime`, `LastPlayTime`, `FaceBookId`) VALUES
('C8F733BF21BA', 20, '2016-07-17 15:50:25', '2016-07-24 08:23:53', '2016-07-24 05:27:03', '2016-07-24 05:17:42', NULL),
('1867B03B3AF7', 376, '2016-07-18 04:33:33', '2016-07-22 04:22:48', '2016-07-21 17:08:55', '2016-07-22 11:40:03', NULL),
('549B12F03961', 499, '2016-07-24 03:30:51', '2016-07-24 06:15:34', '0000-00-00 00:00:00', '2016-07-24 06:17:54', NULL),
('020000000000', 501, '2016-07-24 04:01:40', '2016-07-24 06:27:31', '0000-00-00 00:00:00', '2016-07-24 06:28:27', NULL),
('c49a0264fa35', 527, '2016-07-24 05:58:14', '2016-07-24 06:20:57', '0000-00-00 00:00:00', '2016-07-24 06:21:29', NULL),
('380B40F5D79E', 528, '2016-07-24 06:01:01', '0000-00-00 00:00:00', '0000-00-00 00:00:00', '2016-07-24 06:02:28', NULL),
('080027f06ae8', 534, '2016-07-24 07:46:43', '2016-07-24 07:46:43', '0000-00-00 00:00:00', '0000-00-00 00:00:00', NULL),
('08002789d415', 535, '2016-07-24 07:50:09', '2016-07-24 08:37:31', '0000-00-00 00:00:00', '2016-07-24 08:33:22', NULL),
('9476B776C6DD', 557, '2016-07-24 08:36:03', '2016-07-24 08:36:03', '0000-00-00 00:00:00', '2016-07-24 08:37:06', NULL);

--
-- 덤프된 테이블의 인덱스
--

--
-- 테이블의 인덱스 `rank`
--
ALTER TABLE `rank`
  ADD PRIMARY KEY (`PlayerId`);

--
-- 테이블의 인덱스 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`PlayerId`), ADD UNIQUE KEY `MacAddress` (`MacAddress`);

--
-- 덤프된 테이블의 AUTO_INCREMENT
--

--
-- 테이블의 AUTO_INCREMENT `user`
--
ALTER TABLE `user`
  MODIFY `PlayerId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=559;
--
-- 덤프된 테이블의 제약사항
--

--
-- 테이블의 제약사항 `rank`
--
ALTER TABLE `rank`
ADD CONSTRAINT `fk_id` FOREIGN KEY (`PlayerId`) REFERENCES `user` (`PlayerId`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
