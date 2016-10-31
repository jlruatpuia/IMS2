/*
Navicat MySQL Data Transfer

Source Server         : MySql_localhost
Source Server Version : 50621
Source Host           : 127.0.0.1:3306
Source Database       : ims2

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2016-08-30 10:14:33
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for customer
-- ----------------------------
DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for customeraccount
-- ----------------------------
DROP TABLE IF EXISTS `customeraccount`;
CREATE TABLE `customeraccount` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) DEFAULT NULL,
  `TransDate` date DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Debit` double(255,0) DEFAULT NULL,
  `Credit` double(255,0) DEFAULT NULL,
  `Balance` double(255,0) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_ca_cc` (`CustomerID`),
  CONSTRAINT `fk_ca_cc` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Category` int(255) DEFAULT NULL,
  `SubCategory` varchar(255) DEFAULT NULL,
  `Company` varchar(255) DEFAULT NULL,
  `ProductName` varchar(255) DEFAULT NULL,
  `BuyingValue` double(255,0) DEFAULT NULL,
  `SellingValue` double(255,0) DEFAULT NULL,
  `MfgDate` varchar(255) DEFAULT NULL,
  `ExpDate` varchar(255) DEFAULT NULL,
  `PackageSize` varchar(255) DEFAULT NULL,
  `Quantity` int(255) DEFAULT NULL,
  `BarCode` varchar(255) DEFAULT NULL,
  `SupplierID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_cat_prd` (`Category`),
  CONSTRAINT `fk_cat_prd` FOREIGN KEY (`Category`) REFERENCES `category` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for productdetail
-- ----------------------------
DROP TABLE IF EXISTS `productdetail`;
CREATE TABLE `productdetail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ProductID` int(11) DEFAULT NULL,
  `BuyingValue` double(255,0) DEFAULT NULL,
  `SellingValue` double(255,0) DEFAULT NULL,
  `MfgDate` varchar(255) DEFAULT NULL,
  `ExpDate` varchar(255) DEFAULT NULL,
  `PackageSize` varchar(255) DEFAULT NULL,
  `Quantity` int(255) DEFAULT NULL,
  `BarCode` varchar(255) DEFAULT NULL,
  `SupplierID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fr_prd_pdt` (`ProductID`),
  CONSTRAINT `fr_prd_pdt` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for purchase
-- ----------------------------
DROP TABLE IF EXISTS `purchase`;
CREATE TABLE `purchase` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(50) NOT NULL,
  `PurchaseDate` date NOT NULL,
  `SupplierID` int(11) NOT NULL,
  `Amount` double(255,0) NOT NULL,
  `Payment` double(255,0) NOT NULL,
  `Balance` double(255,0) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_pur_pdt_idx` (`InvoiceNo`),
  KEY `fk_pur_sup_idx` (`SupplierID`),
  CONSTRAINT `fk_pc_pr` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for purchasedetail
-- ----------------------------
DROP TABLE IF EXISTS `purchasedetail`;
CREATE TABLE `purchasedetail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(255) NOT NULL,
  `ProductID` int(255) DEFAULT NULL,
  `Quantity` int(255) NOT NULL,
  `BuyingValue` double(255,0) NOT NULL,
  `SellingValue` double(255,0) NOT NULL,
  `Amount` double(255,0) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_pdt_pur_idx` (`InvoiceNo`),
  CONSTRAINT `purchasedetail_ibfk_1` FOREIGN KEY (`InvoiceNo`) REFERENCES `purchase` (`InvoiceNo`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for sale
-- ----------------------------
DROP TABLE IF EXISTS `sale`;
CREATE TABLE `sale` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(255) DEFAULT NULL,
  `SellDate` date DEFAULT NULL,
  `Customer` int(255) DEFAULT NULL,
  `Amount` double(255,0) DEFAULT NULL,
  `Discount` double(255,0) DEFAULT NULL,
  `Payment` double(255,0) DEFAULT NULL,
  `Balance` double(255,0) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_sl_cc` (`Customer`),
  KEY `InvoiceNo` (`InvoiceNo`),
  CONSTRAINT `fk_sl_cc` FOREIGN KEY (`Customer`) REFERENCES `customer` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for saledetail
-- ----------------------------
DROP TABLE IF EXISTS `saledetail`;
CREATE TABLE `saledetail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(255) DEFAULT NULL,
  `Product` int(255) DEFAULT NULL,
  `Quantity` int(255) DEFAULT NULL,
  `BuyingValue` double(255,0) DEFAULT NULL,
  `SellingValue` double(255,0) DEFAULT NULL,
  `Amount` double(255,0) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_sd_ss` (`InvoiceNo`),
  KEY `fk_sd_pd` (`Product`),
  CONSTRAINT `fk_sd_pd` FOREIGN KEY (`Product`) REFERENCES `product` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_sd_ss` FOREIGN KEY (`InvoiceNo`) REFERENCES `sale` (`InvoiceNo`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for supplier
-- ----------------------------
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SupplierName` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for supplieraccount
-- ----------------------------
DROP TABLE IF EXISTS `supplieraccount`;
CREATE TABLE `supplieraccount` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SupplierID` int(11) NOT NULL,
  `TransDate` date NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Debit` double(255,0) NOT NULL,
  `Credit` double(255,0) NOT NULL,
  `Balance` double(255,0) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_sac_sup_idx` (`SupplierID`),
  CONSTRAINT `supplieraccount_ibfk_1` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
