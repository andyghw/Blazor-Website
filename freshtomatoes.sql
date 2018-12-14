

SET FOREIGN_KEY_CHECKS=0;


DROP TABLE IF EXISTS `comments`;
CREATE TABLE `comments` (
  `commentid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `moviename` varchar(100) DEFAULT NULL,
  `createDate` date DEFAULT NULL,
  `text` text,
  `rating` double DEFAULT NULL,
  PRIMARY KEY (`commentid`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO `comments` VALUES ('1', 'andyghw', 'The Avengers', '2018-12-11', 'Fans of the franchise will be pleased, but those looking in from the outside of comic-book culture may find themselves also looking at their watches.', '4.5');
INSERT INTO `comments` VALUES ('3', 'Hanwen', 'The Avengers', '2018-12-11', 'Fantastic one. I love it!!!!1', '5');
INSERT INTO `comments` VALUES ('4', 'Hanwen', 'The Avengers', '2018-12-11', 'Trash movie. A waste of time and money.', '1');
INSERT INTO `comments` VALUES ('5', 'andyghw', 'The Avengers', '2018-12-11', 'Good one but nothing unexpected.', '3');
INSERT INTO `comments` VALUES ('12', 'Hanwen', 'The Avengers', '2018-12-13', 'Perfect movie. Really exciting.', '4');
INSERT INTO `comments` VALUES ('15', 'andyghw', 'The Avengers', '2018-12-13', 'Not bad, but not as good as I expected...', '3');
INSERT INTO `comments` VALUES ('16', 'Hanwen', 'Venom', '2018-12-13', 'A good movie. But not as perfect as I expected.', '3');
INSERT INTO `comments` VALUES ('17', 'Hanwen', 'Friends', '2018-12-13', 'A classic series which grew with me.', '5');
INSERT INTO `comments` VALUES ('19', 'dino', 'Star Wars: Episode IV - A New Hope', '2018-12-13', 'An old movie, but really classic and exciting.', '4');


DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(50) NOT NULL,
  `role` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO `users` VALUES ('1', 'andyghw', 'guo.hanw@husky.neu.edu', '19950116', null);
INSERT INTO `users` VALUES ('3', 'gbjk', 'gbjk1216@sina.com', '19671216', null);
INSERT INTO `users` VALUES ('5', 'Hanwen', '19950116ghw@gmail.com', 'None', null);
INSERT INTO `users` VALUES ('6', 'dino', 'c.konstantopoulos@northeastern.edu', 'thegreatdino', null);
