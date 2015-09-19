/*
SQLyog Ultimate v9.01 
MySQL - 5.5.36 : Database - db_retail
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

/*Table structure for table `tb_barang` */

DROP TABLE IF EXISTS `tb_barang`;

CREATE TABLE `tb_barang` (
  `id_barang` varchar(10) NOT NULL,
  `id_kategori` varchar(10) DEFAULT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `satuan` varchar(100) DEFAULT NULL,
  `harga` int(100) DEFAULT NULL,
  PRIMARY KEY (`id_barang`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `tb_barang` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_detail_pembelian` */

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_detail_penjualan` */

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
  `catatan` varchar(200) DEFAULT NULL,
  `kategori` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_barang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_master_barang` */

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
  `tanggal` date DEFAULT NULL,
  `total_pembelian` double DEFAULT NULL,
  `total_bayar` double DEFAULT NULL,
  `id_pegawai` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`no_faktur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_pembelian` */

/*Table structure for table `tb_penjualan` */

DROP TABLE IF EXISTS `tb_penjualan`;

CREATE TABLE `tb_penjualan` (
  `no_faktur` varchar(20) NOT NULL,
  `tanggal_transaksi` date DEFAULT NULL,
  `total_penjualan` double DEFAULT NULL,
  `total_bayar` double DEFAULT NULL,
  `kembali` double DEFAULT NULL,
  `id_pegawai` varchar(10) DEFAULT NULL,
  `jenis_pembayaran` varchar(10) DEFAULT NULL,
  `no_kartu` varchar(20) DEFAULT NULL,
  `jenis_kartu` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`no_faktur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_penjualan` */

/*Table structure for table `tb_stok` */

DROP TABLE IF EXISTS `tb_stok`;

CREATE TABLE `tb_stok` (
  `id_stok` int(10) NOT NULL AUTO_INCREMENT,
  `id_barang` varchar(10) DEFAULT NULL,
  `stok_barang` int(10) DEFAULT NULL,
  `harga_beli` double DEFAULT NULL,
  `tgl_stok` date DEFAULT NULL,
  PRIMARY KEY (`id_stok`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_stok` */

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

insert  into `tb_user`(`id_user`,`id_pegawai`,`role`,`namauser`,`sandi`,`status`,`last_login`) values (1,'00001','admin','admin','admin',1,'2015-09-18 12:57:33');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
