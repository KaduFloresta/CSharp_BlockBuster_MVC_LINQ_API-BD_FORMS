-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 30-Maio-2020 às 07:52
-- Versão do servidor: 10.4.8-MariaDB
-- versão do PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `locadorakadu`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `clientes`
--

CREATE TABLE `clientes` (
  `IdCliente` int(11) NOT NULL,
  `NomeCliente` longtext NOT NULL,
  `DataNascimento` longtext NOT NULL,
  `CpfCliente` longtext NOT NULL,
  `DiasDevolucao` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `clientes`
--

INSERT INTO `clientes` (`IdCliente`, `NomeCliente`, `DataNascimento`, `CpfCliente`, `DiasDevolucao`) VALUES
(1, 'Adriano Medeiros Sá', '21/01/1978', '123.123.123-12', 1),
(2, 'João Pedro Silva', '13/08/1945', '456.456.456-56', 2),
(3, 'Maria de Fátima Antunes', '02/12/2001', '789.789.789-78', 3),
(4, 'Letícia Eugenia Soares', '11/02/1988', '159.159.159-15', 4),
(5, 'Belmiro Schmmitt', '15/07/1995', '753.753.753-75', 5),
(6, 'João Pedro Ribeiro', '12/02/1960', '111.111.111-11', 4),
(7, 'Carolina Castro de Almeida', '04/08/1998', '222.222.222-22', 3),
(8, 'Mario Henrique Souza', '22/05/1978', '333.333.333-33', 3),
(9, 'Geraldo Martins Figueira', '29/03/2001', '444.444.444-44', 2),
(10, 'Odila Simão da Cruz Limeira', '07/11/1965', '555.555.555-55', 3),
(11, 'Jackson Machado', '11/11/1956', '124.541.212-45', 2),
(12, 'Luiza Andres', '15/11/1978', '465.456.454-56', 3),
(13, 'Diogo Bortolini', '11/10/1958', '123.123.130-12', 4),
(14, 'Katia Regina De Souza', '02/09/1978', '787.878.787-87', 2),
(15, 'Josefa Antonieta de Albuquerque', '10/12/1942', '456.456.456-45', 10),
(16, 'Helio Arantes', '05/02/1991', '123.131.313-21', 2),
(17, 'Julio Henrique Drummond', '2/10/1980', '987.654.321-00', 4),
(18, 'Katia Regina SIlva', '3/5/2002', '321.654.897-97', 3),
(19, 'Paulo Eduardo Medina', '28/9/1972', '951.753.159-25', 10),
(20, 'José Maria Lima de Jesus', '1/2/1975', '159.847.263-52', 3),
(21, 'Arlete Campos Velasquez', '5/4/1993', '789.789.789-78', 2),
(22, 'Carlos Eduardo Floresta', '10/1/1978', '010.203.040-50', 10),
(23, 'Luana Laurentino', '14/2/1976', '784.864.321-32', 4),
(24, 'Karina Medina Lins', '15/01/1988', '313.131.313-12', 10),
(25, 'Paula Jasmine Gomes', '30/6/1968', '789.987.789-63', 10),
(26, 'Leonardo Furlang Noronha', '31/12/1999', '111.111.111-11', 5),
(27, 'Mauro Beltrão Osni', '19/2/1998', '555.444.333-22', 3),
(28, 'Osvaldo Helio Mendonça', '5/12/2003', '333.333.333-33', 3),
(29, 'Danilo da Cruz Limeira', '23/8/2005', '656.565.656-56', 4),
(30, 'Tulio Guilherme Balboa', '7/7/2001', '787.546.131-68', 3),
(31, 'Ana Lucia Nogueira', '15/5/1965', '999.999.999-99', 2),
(32, 'Samantha Lopes Moura', '15/12/1996', '252.525.252-52', 3),
(33, 'Marcelo Antunes de Oliveira', '15/9/1975', '888.888.888-88', 4),
(34, 'Elaine Geralda Correa', '2/2/1964', '888.555.222-36', 3),
(35, 'Getulio Vargas Aparecido', '14/11/1957', '897.897.897-89', 4);

-- --------------------------------------------------------

--
-- Estrutura da tabela `filmes`
--

CREATE TABLE `filmes` (
  `IdFilme` int(11) NOT NULL,
  `Titulo` longtext NOT NULL,
  `DataLancamento` longtext NOT NULL,
  `Sinopse` longtext NOT NULL,
  `ValorLocacaoFilme` double NOT NULL,
  `EstoqueFilme` int(11) NOT NULL,
  `FilmeLocado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `filmes`
--

INSERT INTO `filmes` (`IdFilme`, `Titulo`, `DataLancamento`, `Sinopse`, `ValorLocacaoFilme`, `EstoqueFilme`, `FilmeLocado`) VALUES
(1, 'Ben Hur', '25/01/1958', 'Ben-Hur é um mercador judeu que, após um desentendimento, é condenado a viver como escravo por um amigo de juventude Messala, que é o chefe das legiões romanas da cidade. Mas uma surpreendente oportunidade de vingança surge de onde ele menos espera.', 3.99, 2, 0),
(2, 'Encontro Marcado', '08/10/1998', 'Quando o Anjo da Morte chega à Terra para buscar um magnata da mídia, suas experiências como mortal o levam a se apaixonar pela filha do milionário. A Morte então decide fazer um acordo com o empresário para que ambos possam permanecer mais tempo na Terra.\r\n', 3.99, 2, 0),
(3, 'Crash', '01/05/2004', 'Tensões raciais emergem em uma série de histórias envolvendo moradores de Los Angeles. Diversos personagens das mais variadas origens étnicas se cruzam em um incidente. Os diferentes estereótipos que a sociedade criou para esses grupos raciais afeta seu julgamento, crenças e atitudes, o que causa problemas e tensões para todos.', 4.99, 3, 0),
(4, 'Endiabrado', '20/11/2004', 'Desesperado para ganhar a afeição de uma bela colega de trabalho, Elliot faz um acordo com o Diabo, uma mulher maravilhosa, com um perverso senso de humor. Em troca da alma de Elliot, ela vai lhe conceder sete desejos, mas a cada desejo, ele recebe mais do que pede.', 4.99, 3, 0),
(5, 'Tomates Verdes Fritos', '10/04/1992', 'Evelyn Couch (Kathy Bates) visita com o marido um parente no asilo de idosos. Uma vez lá, ela encontra Ninny Threadgoode (Jessica Tandy), uma mulher idosa, que a ilumina e traz uma nova perspectiva através de contos do seu passado. Evelyn ganha a\r\nconfiança necessária para mudar sua própria vida para melhor.', 2.99, 2, 0),
(6, 'Robocop', '18/09/1987', 'Policial é morto em combate e transformado por cientistas da empresa que dirige a força policial em um ciborgue ultra sofisticado a fim de ser usado na luta contra o crime na cidade de Detroit. Porém, apesar de ter sua memória apagada, lembranças o assombram e o levam a buscar vingança.', 2.99, 2, 0),
(7, 'Harry Potte e o Prisioneiro de Azkaban', '07/08/2004', 'O terceiro ano de Harry Potter em Hogwarts começa mal quando ele descobre que o assassino Sirius Black escapou da prisão de Azkaban e está empenhado em matá-lo. Enquanto o gato de Hermione atormenta o rato doente de Ron, um bando de dementadores são enviados para proteger a escola de Sirius Black. Um professor misterioso ajuda Harry a aprender a se defender.', 4.99, 4, 0),
(8, 'Psicose', '15/10/1960', 'Após roubar 40 mil dólares para se casar com o namorado, uma mulher foge durante uma tempestade e decide passar a noite em um hotel que encontra pelo caminho. Ela conhece o educado e nervoso proprietário do estabelecimento, Norman Bates, um jovem com um interesse em taxidermia e com uma relação conturbada com sua mãe. O que parece ser uma simples estadia no local se torna uma\r\nverdadeira noite de terror.', 2.99, 2, 0),
(9, 'Jamaica Abaixo de Zero', '07/05/1993', 'Quatro jamaicanos praticantes de bobsleigh sonham em competir nos Jogos Olímpicos de Inverno, apesar de nunca terem visto neve. Com a ajuda de um ex-campeão desonrado desesperado para se redimir, os jamaicanos decidem tentar a classificação para a seleção olímpica e buscar a glória.', 2.99, 4, 0),
(10, 'Vingadores Ultimato', '16/07/2019', 'Após Thanos eliminar metade das criaturas vivas, os Vingadores têm de lidar com a perda de amigos e entes queridos. Com Tony Stark vagando perdido no espaço sem água e comida, Steve Rogers e Natasha Romanov lideram a resistência contra o titã louco.', 5.99, 5, 0),
(11, 'O Homem Invisível', '27/02/2020', 'Depois de forjar o próprio suicídio, um cientista enlouquecido usa seu poder para se tornar invisível e aterrorizar sua ex-namorada. Quando a polícia se recusa a acreditar em sua história, ela decide resolver o assunto por conta própria.', 5.99, 5, 0),
(12, 'Cleópatra', '12/06/1963', 'Temendo a expansão dos romanos, Cleópatra convence Júlio César a formar uma aliança, para que ela continue controlando o império e faz com que ele desista de invadir o Egito, porém, o imperador é assassinado no senado romano.', 3.99, 2, 0),
(13, 'O Hobbit: Uma Jornada Inesperada', '14/12/2017', 'Como a maioria dos hobbits, Bilbo Bolseiro leva uma vida tranquila até o dia em que recebe uma missão do mago Gandalf. Acompanhado por um grupo de anões, ele parte numa jornada até a Montanha Solitária para libertar o Reino de Erebor do dragão Smaug.', 3.99, 3, 0),
(14, 'Kick Ass - Quebrando Tudo', '18/6/2010', 'Usando sua paixão por histórias em quadrinhos, o adolescente Dave Lizewski decide se reinventar como super-herói, apesar da total falta de poderes especiais. O adolescente arruma uma fantasia, batiza-se de \"Kick-Ass\" e começa a combater o crime com a ajuda de amigos justiceiros.', 4.99, 3, 0),
(15, 'Greta', '11/11/2009', 'Uma adolescente rebelde e suicida é enviada para a casa de seus avós no verão, onde sua vida toma um rumo inesperado.', 2.99, 2, 0),
(16, 'V de Vingança', '7/4/2006', 'Após uma guerra mundial, a Inglaterra é ocupada por um governo fascista e vive sob um regime totalitário. Na luta pela liberdade, um vigilante, conhecido apenas por V, utiliza-se de táticas terroristas para enfrentar os opressores da sociedade.', 3.99, 3, 0),
(17, 'Debi & Loide - Dois Idiotas em Apuros', '27/2/1995', 'Dois amigos debilóides vão para Aspen, no estado do Colorado para tentar devolver uma maleta esquecida pela passageira da limusine que um deles estava dirigindo para o aeroporto.', 2.99, 2, 0),
(18, 'Amor Além da Vida', '2/10/1998', 'Chris e Annie Nielsen são muito felizes, até seus dois filhos morrerem em um acidente. Com muito custo, eles superam o desespero, porém, quando Chris também morre em um acidente quatro anos mais tarde, Annie não aguenta e se suicida. Ele acorda no Paraíso e é avisado de que o espírito dela está aprisionado e só poderá ser libertado se ele fizer uma perigosa jornada para encontrá-la.', 2.99, 2, 0),
(19, 'X-Men: Apocalipse', '19/5/2016', 'O primeiro mutante destruidor do mundo, Apocalipse, está de volta disposto a acabar com a humanidade. Professor Xavier conta com Mística, Fera e Mercúrio, além de novos alunos, para impedir o vilão.', 4.99, 3, 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `locacaofilme`
--

CREATE TABLE `locacaofilme` (
  `Id` int(11) NOT NULL,
  `IdLocacao` int(11) NOT NULL,
  `LocacaoIdLocacao` int(11) DEFAULT NULL,
  `IdFilme` int(11) NOT NULL,
  `FilmeIdFilme` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `locacaofilme`
--

INSERT INTO `locacaofilme` (`Id`, `IdLocacao`, `LocacaoIdLocacao`, `IdFilme`, `FilmeIdFilme`) VALUES
(1, 1, NULL, 1, NULL),
(2, 2, NULL, 1, NULL),
(3, 2, NULL, 2, NULL),
(4, 3, NULL, 1, NULL),
(5, 3, NULL, 3, NULL),
(6, 3, NULL, 5, NULL),
(7, 4, NULL, 13, NULL),
(8, 4, NULL, 14, NULL),
(9, 4, NULL, 15, NULL),
(10, 4, NULL, 16, NULL),
(11, 5, NULL, 3, NULL),
(12, 5, NULL, 6, NULL),
(13, 5, NULL, 10, NULL),
(14, 5, NULL, 11, NULL),
(15, 5, NULL, 16, NULL),
(16, 6, NULL, 2, NULL),
(17, 6, NULL, 6, NULL),
(18, 7, NULL, 1, NULL),
(19, 7, NULL, 3, NULL),
(20, 7, NULL, 5, NULL),
(21, 7, NULL, 7, NULL),
(22, 7, NULL, 9, NULL),
(23, 7, NULL, 11, NULL),
(24, 7, NULL, 13, NULL),
(25, 7, NULL, 15, NULL),
(26, 8, NULL, 1, NULL),
(27, 8, NULL, 2, NULL),
(28, 8, NULL, 3, NULL),
(29, 8, NULL, 4, NULL),
(30, 8, NULL, 5, NULL),
(31, 8, NULL, 6, NULL),
(32, 8, NULL, 7, NULL),
(33, 8, NULL, 8, NULL),
(34, 8, NULL, 9, NULL),
(35, 8, NULL, 10, NULL),
(36, 8, NULL, 11, NULL),
(37, 8, NULL, 12, NULL),
(38, 8, NULL, 13, NULL),
(39, 8, NULL, 14, NULL),
(40, 8, NULL, 15, NULL),
(41, 8, NULL, 16, NULL),
(42, 9, NULL, 1, NULL),
(43, 9, NULL, 3, NULL),
(44, 10, NULL, 13, NULL),
(45, 10, NULL, 14, NULL),
(46, 12, NULL, 1, NULL),
(47, 12, NULL, 2, NULL),
(48, 13, NULL, 5, NULL),
(49, 13, NULL, 8, NULL),
(50, 14, NULL, 1, NULL),
(51, 14, NULL, 2, NULL),
(52, 14, NULL, 5, NULL),
(53, 14, NULL, 16, NULL),
(54, 15, NULL, 2, NULL),
(55, 15, NULL, 4, NULL),
(56, 15, NULL, 14, NULL),
(57, 17, NULL, 1, NULL),
(58, 17, NULL, 2, NULL),
(59, 18, NULL, 2, NULL),
(60, 18, NULL, 4, NULL),
(61, 19, NULL, 3, NULL),
(62, 19, NULL, 12, NULL),
(63, 20, NULL, 18, NULL),
(64, 21, NULL, 18, NULL),
(65, 22, NULL, 1, NULL),
(66, 22, NULL, 16, NULL),
(67, 22, NULL, 18, NULL),
(68, 23, NULL, 2, NULL),
(69, 23, NULL, 7, NULL),
(70, 23, NULL, 18, NULL),
(71, 23, NULL, 19, NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `locacoes`
--

CREATE TABLE `locacoes` (
  `IdLocacao` int(11) NOT NULL,
  `ClienteIdCliente` int(11) DEFAULT NULL,
  `DataLocacao` datetime(6) NOT NULL,
  `IdCliente` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `locacoes`
--

INSERT INTO `locacoes` (`IdLocacao`, `ClienteIdCliente`, `DataLocacao`, `IdCliente`) VALUES
(1, NULL, '2020-05-28 03:10:59.666614', 1),
(2, NULL, '2020-05-28 03:11:09.339931', 2),
(3, NULL, '2020-05-28 03:11:18.927085', 3),
(4, NULL, '2020-05-28 03:11:52.519109', 4),
(5, NULL, '2020-05-28 03:12:23.390145', 19),
(6, NULL, '2020-05-28 03:12:36.407228', 13),
(7, NULL, '2020-05-28 03:13:02.579179', 11),
(8, NULL, '2020-05-28 03:14:32.230864', 15),
(9, NULL, '2020-05-28 03:34:16.215178', 1),
(10, NULL, '2020-05-28 03:39:03.914493', 10),
(11, NULL, '2020-05-28 03:50:22.125440', 4),
(12, NULL, '2020-05-28 03:58:08.924494', 1),
(13, NULL, '2020-05-28 04:19:03.294311', 2),
(14, NULL, '2020-05-28 04:25:38.599093', 22),
(15, NULL, '2020-05-28 15:06:43.770282', 17),
(16, NULL, '2020-05-29 19:36:08.332557', 3),
(17, NULL, '2020-05-29 19:41:06.309175', 2),
(18, NULL, '2020-05-29 20:15:34.161200', 29),
(19, NULL, '2020-05-29 20:15:55.316000', 29),
(20, NULL, '2020-05-29 22:55:09.105992', 32),
(21, NULL, '2020-05-29 22:56:30.313006', 31),
(22, NULL, '2020-05-30 01:10:41.869522', 34),
(23, NULL, '2020-05-30 02:51:35.730129', 35);

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200406232609_Migracao', '3.1.2'),
('20200407223848_CriaRelacao', '3.1.2'),
('20200407232746_RelacaoBd', '3.1.2');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`IdCliente`);

--
-- Índices para tabela `filmes`
--
ALTER TABLE `filmes`
  ADD PRIMARY KEY (`IdFilme`);

--
-- Índices para tabela `locacaofilme`
--
ALTER TABLE `locacaofilme`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_LocacaoFilme_FilmeIdFilme` (`FilmeIdFilme`),
  ADD KEY `IX_LocacaoFilme_LocacaoIdLocacao` (`LocacaoIdLocacao`);

--
-- Índices para tabela `locacoes`
--
ALTER TABLE `locacoes`
  ADD PRIMARY KEY (`IdLocacao`),
  ADD KEY `IX_Locacoes_ClienteIdCliente` (`ClienteIdCliente`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `clientes`
--
ALTER TABLE `clientes`
  MODIFY `IdCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT de tabela `filmes`
--
ALTER TABLE `filmes`
  MODIFY `IdFilme` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `locacaofilme`
--
ALTER TABLE `locacaofilme`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=72;

--
-- AUTO_INCREMENT de tabela `locacoes`
--
ALTER TABLE `locacoes`
  MODIFY `IdLocacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `locacaofilme`
--
ALTER TABLE `locacaofilme`
  ADD CONSTRAINT `FK_LocacaoFilme_Filmes_FilmeIdFilme` FOREIGN KEY (`FilmeIdFilme`) REFERENCES `filmes` (`IdFilme`),
  ADD CONSTRAINT `FK_LocacaoFilme_Locacoes_LocacaoIdLocacao` FOREIGN KEY (`LocacaoIdLocacao`) REFERENCES `locacoes` (`IdLocacao`);

--
-- Limitadores para a tabela `locacoes`
--
ALTER TABLE `locacoes`
  ADD CONSTRAINT `FK_Locacoes_Clientes_ClienteIdCliente` FOREIGN KEY (`ClienteIdCliente`) REFERENCES `clientes` (`IdCliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
