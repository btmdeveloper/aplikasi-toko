/*
SQLyog Ultimate v9.01 
MySQL - 5.1.30-community : Database - db_retail
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_retail` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_retail`;

/*Table structure for table `tb_detail_pembelian` */

DROP TABLE IF EXISTS `tb_detail_pembelian`;

CREATE TABLE `tb_detail_pembelian` (
  `id_detail` int(10) NOT NULL AUTO_INCREMENT,
  `no_faktur` varchar(20) DEFAULT NULL,
  `id_barang` varchar(10) DEFAULT NULL,
  `harga_beli` double DEFAULT NULL,
  `jumlah_barang` int(10) DEFAULT NULL,
  `diskon` double DEFAULT NULL,
  `total` double DEFAULT NULL,
  `stok_awal` int(10) DEFAULT NULL,
  `stok_akhir` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `tb_detail_pembelian` */

insert  into `tb_detail_pembelian`(`id_detail`,`no_faktur`,`id_barang`,`harga_beli`,`jumlah_barang`,`diskon`,`total`,`stok_awal`,`stok_akhir`) values (1,'1','1',1000,1,0,1000,0,1),(2,'1','1',2000,1,0,2000,1,2),(3,'2','1',1000,10,10,9000,2,12),(4,'3','1',1000,1,0,1000,12,13),(5,'3','2',1000,10,0,10000,0,10);

/*Table structure for table `tb_detail_penjualan` */

DROP TABLE IF EXISTS `tb_detail_penjualan`;

CREATE TABLE `tb_detail_penjualan` (
  `id_detail` int(10) NOT NULL AUTO_INCREMENT,
  `no_faktur` varchar(20) DEFAULT NULL,
  `id_barang` varchar(10) DEFAULT NULL,
  `harga_jual` double DEFAULT NULL,
  `jumlah_barang` int(10) DEFAULT NULL,
  `diskon` double DEFAULT NULL,
  `total_jual` double DEFAULT NULL,
  `harga_beli` double DEFAULT NULL,
  `total_beli` double DEFAULT NULL,
  `stok_awal` int(10) DEFAULT NULL,
  `stok_akhir` int(10) DEFAULT NULL,
  PRIMARY KEY (`id_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `tb_detail_penjualan` */

insert  into `tb_detail_penjualan`(`id_detail`,`no_faktur`,`id_barang`,`harga_jual`,`jumlah_barang`,`diskon`,`total_jual`,`harga_beli`,`total_beli`,`stok_awal`,`stok_akhir`) values (1,'1','1',2000,2,0,4000,1000,2000,13,11),(2,'1','1',2000,1,0,2000,2000,2000,11,10),(3,'1','1',2000,1,0,2000,900,900,10,9),(4,'2','1',2000,3,0,6000,1000,3000,13,10),(5,'2','1',2000,1,0,2000,2000,2000,10,9),(6,'2','2',3000,3,0,9000,1000,3000,13,10),(7,'2','2',3000,1,0,3000,1000,1000,10,9),(8,'3','1',2000,1,0,2000,900,900,9,8),(9,'3','1',2000,8,10,14400,900,7200,8,0);

/*Table structure for table `tb_harga_jual` */

DROP TABLE IF EXISTS `tb_harga_jual`;

CREATE TABLE `tb_harga_jual` (
  `id_row` int(10) NOT NULL AUTO_INCREMENT,
  `id_barang` varchar(10) DEFAULT NULL,
  `harga_jual` double DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  PRIMARY KEY (`id_row`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_harga_jual` */

/*Table structure for table `tb_kategori_barang` */

DROP TABLE IF EXISTS `tb_kategori_barang`;

CREATE TABLE `tb_kategori_barang` (
  `id_kategori` varchar(10) NOT NULL,
  `kategori` varchar(100) DEFAULT NULL,
  `keterangan` varchar(200) DEFAULT NULL,
  `foto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_kategori`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `tb_kategori_barang` */

/*Table structure for table `tb_master_barang` */

DROP TABLE IF EXISTS `tb_master_barang`;

CREATE TABLE `tb_master_barang` (
  `id_barang` varchar(10) NOT NULL,
  `nama_barang` varchar(200) DEFAULT NULL,
  `satuan` varchar(10) DEFAULT NULL,
  `harga_jual` double DEFAULT NULL,
  PRIMARY KEY (`id_barang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_master_barang` */

insert  into `tb_master_barang`(`id_barang`,`nama_barang`,`satuan`,`harga_jual`) values ('1','aqua','botol',2000),('2','aqua besar','botol',3000),('3','club tanggung','botol',3000),('4','cocacola','botol',2000),('5','sprite 1 liter','saset',2500);

/*Table structure for table `tb_master_pegawai` */

DROP TABLE IF EXISTS `tb_master_pegawai`;

CREATE TABLE `tb_master_pegawai` (
  `id_pegawai` varchar(10) NOT NULL,
  `nama_depan` varchar(50) DEFAULT NULL,
  `nama_belakang` varchar(50) DEFAULT NULL,
  `no_telp` varchar(20) DEFAULT NULL,
  `alamat` varchar(100) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  PRIMARY KEY (`id_pegawai`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_master_pegawai` */

insert  into `tb_master_pegawai`(`id_pegawai`,`nama_depan`,`nama_belakang`,`no_telp`,`alamat`,`status`) values ('00001','admin','admin','-','-',1);

/*Table structure for table `tb_pembelian` */

DROP TABLE IF EXISTS `tb_pembelian`;

CREATE TABLE `tb_pembelian` (
  `no_faktur` varchar(20) NOT NULL,
  `tgl_pembelian` datetime DEFAULT NULL,
  `total_pembelian` double DEFAULT NULL,
  `total_bayar` double DEFAULT NULL,
  `kembali` double DEFAULT NULL,
  `id_pegawai` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`no_faktur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_pembelian` */

insert  into `tb_pembelian`(`no_faktur`,`tgl_pembelian`,`total_pembelian`,`total_bayar`,`kembali`,`id_pegawai`) values ('1','2015-09-20 11:18:11',3000,5000,2000,'00001'),('2','2015-09-20 11:19:29',9000,70000,61000,'00001'),('3','2015-09-20 11:20:50',11000,20000,9000,'00001');

/*Table structure for table `tb_penjualan` */

DROP TABLE IF EXISTS `tb_penjualan`;

CREATE TABLE `tb_penjualan` (
  `no_faktur` varchar(20) NOT NULL,
  `tgl_penjualan` datetime DEFAULT NULL,
  `total_penjualan` double DEFAULT NULL,
  `total_bayar` double DEFAULT NULL,
  `kembali` double DEFAULT NULL,
  `id_pegawai` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`no_faktur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_penjualan` */

insert  into `tb_penjualan`(`no_faktur`,`tgl_penjualan`,`total_penjualan`,`total_bayar`,`kembali`,`id_pegawai`) values ('1','2015-09-20 14:47:14',8000,10000,2000,'00001'),('2','2015-09-20 14:50:07',20000,100000,80000,'00001'),('3','2015-09-20 14:54:05',16400,120000,103600,'00001');

/*Table structure for table `tb_stok` */

DROP TABLE IF EXISTS `tb_stok`;

CREATE TABLE `tb_stok` (
  `id_stok` int(10) NOT NULL AUTO_INCREMENT,
  `id_barang` varchar(10) DEFAULT NULL,
  `stok_barang` int(10) DEFAULT NULL,
  `harga_beli` double DEFAULT NULL,
  `tanggal_stok` datetime DEFAULT NULL,
  PRIMARY KEY (`id_stok`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `tb_stok` */

insert  into `tb_stok`(`id_stok`,`id_barang`,`stok_barang`,`harga_beli`,`tanggal_stok`) values (1,'1',0,0,'2015-09-20 07:15:22'),(2,'2',0,1000,'2015-09-20 14:50:07'),(3,'3',0,0,'2015-09-20 07:16:51'),(4,'1',0,4,'2015-09-20 07:16:51'),(5,'4',0,0,'2015-09-20 07:44:49'),(6,'5',0,0,'2015-09-20 07:52:39'),(7,'1',0,1000,'2015-09-20 14:50:07'),(8,'1',0,2000,'2015-09-20 14:50:07'),(9,'1',0,900,'2015-09-20 14:54:05'),(10,'2',9,1000,'2015-09-20 14:50:07');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `id_pegawai` varchar(10) DEFAULT NULL,
  `role` varchar(20) DEFAULT NULL,
  `namauser` varchar(20) DEFAULT NULL,
  `sandi` varchar(20) DEFAULT NULL,
  `status` int(1) DEFAULT NULL,
  `last_login` datetime DEFAULT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `tb_user` */

insert  into `tb_user`(`id_user`,`id_pegawai`,`role`,`namauser`,`sandi`,`status`,`last_login`) values (1,'00001','admin','admin','admin',1,'2015-09-20 14:52:52');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
