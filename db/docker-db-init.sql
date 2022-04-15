USE [master]
GO

IF DB_ID('PUC-DBBroker') IS NOT NULL
  set noexec on               -- prevent creation when already exists

/****** Object:  Database [PUC-DBBroker]    Script Date: 18.10.2019 18:33:09 ******/
CREATE DATABASE [PUC-DBBroker];
GO

USE [PUC-DBBroker]
GO