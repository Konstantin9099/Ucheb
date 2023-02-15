CREATE DATABASE `ucheb`  ;
USE `ucheb` ;

--
-- Table `courier`
--
CREATE TABLE `courier` (
  `cour_id` int NOT NULL AUTO_INCREMENT,
  `cour_name` varchar(50) NOT NULL,
  `cour_status` int DEFAULT NULL,
  PRIMARY KEY (`cour_id`),
  KEY `fk_courier_statuses` (`cour_status`),
  CONSTRAINT `fk_courier_statuses`
FOREIGN KEY (`cour_status`)
REFERENCES `statuses` (`status_id`));

--
-- Dumping data for table `courier`
--
INSERT INTO `courier` VALUES (1,'Булкин Илья Владимирович',NULL),(2,'Иванов Иван Иванович',NULL),(3,'Орлов Андрей Алексеевич',NULL);

--
-- Table `delivery`
--
CREATE TABLE `delivery` (
  `del_id` int NOT NULL AUTO_INCREMENT,
  `del_date` date NOT NULL,
  `del_recive` int NOT NULL,
  `del_courier` int DEFAULT NULL,
  `del_list` varchar(200) NOT NULL,
  `del_comm` varchar(200) DEFAULT NULL,
  `del_status` int DEFAULT NULL,
  PRIMARY KEY (`del_id`),
  KEY `fk_delivery_users` (`del_recive`),
  KEY `fk_delivery_courier` (`del_courier`),
  KEY `fk_delivery_statuses` (`del_status`),
  CONSTRAINT `fk_delivery_courier`
FOREIGN KEY (`del_courier`)
REFERENCES `courier` (`cour_id`),
  CONSTRAINT `fk_delivery_statuses`
FOREIGN KEY (`del_status`)
REFERENCES `statuses` (`status_id`),
  CONSTRAINT `fk_delivery_users`
FOREIGN KEY (`del_recive`)
REFERENCES `users` (`user_id`));

--
-- Dumping data for table `delivery`
--
INSERT INTO `delivery` VALUES (1,'2023-02-01',2,1,'Пицца Английский завтрак 1 шт.',NULL,2),(2,'2023-02-03',2,2,'Заказ ? 657846543  из Командора ',NULL,2),(3,'2023-02-04',2,3,'Заказ ? 456410 из Леруа Мерлен ','Забрать 10.02.2023 в 15:00 в ТЦ Планета (вход 3)',2),(4,'2023-02-05',3,2,'Картофель 50 кг.','Забрать с базы Фермер, ул. Линейная, 3, скл. 4',2),(5,'2023-02-13',2,3,'Заказ ?1365132 из DNS','Забрать до 15.02.23 по адресу ул. Ленина, 125',2),(6,'2023-02-16',2,2,'Сахар 50 кг','Заказ 12645113 в ТЦ Аллея, ул. Мира, 135. Забрать заказ до 20.02.2023 включительно.',2),(7,'2023-02-16',3,2,'Диван ','Заказ 53213 в ТЦ КМК пр. Кр. рабочий, 21. Забрать до 18.02.2023 тел. 89634567825',1);

--
-- Table `statuses`
--
CREATE TABLE `statuses` (
  `status_id` int NOT NULL AUTO_INCREMENT,
  `status_name` varchar(20) NOT NULL,
  PRIMARY KEY (`status_id`));

--
-- Dumping data for table `statuses`
--
INSERT INTO `statuses` VALUES (1,'В пути'),(2,'Доставлено'),(3,'Отказ'),(4,'Создано');

--
-- Table  `users`
--
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `user_log` varchar(50) DEFAULT NULL,
  `user_pwd` varchar(20) DEFAULT NULL,
  `user_name` varchar(100) DEFAULT NULL,
  `user_adress` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
);

--
-- Dumping data for table `users`
--
INSERT INTO `users` VALUES (1,'0000','0000','0000','0000'),(2,'2222','2222','Ваcильев Василий Васильевич','г. Омск, ул. Октябрьская, д. 25, кв. 15'),(3,'3333','3333','Иванов Иван Иванович','г. Красноярск, ул. Металлургов, дом 54, кв. 12'),(4,'4444','4444','Петров Петров Петров','г. Красноярск, ул. Д. Мартынова, д. 32, кв. 105');
