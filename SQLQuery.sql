drop database train_test

create database train_test

use train_test

create table train(
t_id int identity primary key,
t_name varchar(255)
)

create table station(
s_id int identity primary key,
s_name varchar(255)
)



create table TrainSchedule(
id int identity primary key,
ts_trainId int foreign key references train(t_id),
fromStaion int foreign key references station(s_id),
toStation int foreign key references station(s_id),
arrivalTime time,
departureTime time,
startDate date,
)

CREATE TABLE TrainRoute (
    RouteId INT Identity PRIMARY KEY,
    TrainId INT FOREIGN KEY REFERENCES train(t_id),
    StationId INT FOREIGN KEY REFERENCES station(s_id),
    StopOrder INT NOT NULL,
    ArrivalTime TIME,
    DepartureTime TIME,
    Distance DECIMAL(10, 2)    
);

create table StationDistance(
SD_Id int identity primary key,
FromStationId int foreign key references station(s_id),
ToStationId int foreign key references station(s_id),
distance int
)

insert into station values('Karachi'),('Hyderabad'),('Mirpur'),('Sukkur')

insert into train values('Khaibarmail'),('tezgam'),('KarachiExpress'),('RehmanBaba')



insert into TrainRoute values
(1,1,1,Null,'07:00:00',Null),
(1,2,2,'10:30:00','10:45:00',20),
(1,3,3,'13:00:00','13:10:00',300),
(1,4,4,'17:20:00','17:30:00',300)

insert into TrainSchedule values
(2,1,2,'10:00:24','10:15:24','2024-01-10'),
(2,2,3,'13:00:24','13:15:24','2024-01-10'),
(2,3,4,'17:15:24','17:30:24','2024-01-10')

select * from TrainSchedule ts inner join train t on ts.ts_trainId=t.t_id inner join station s on ts.fromStaion=s.s_id inner join station st on st.s_id=ts.toStation where startDate='2024-01-10'

select count(t.t_id) as [Train] from TrainSchedule ts inner join train t on ts.ts_trainId=t.t_id inner join station s on ts.fromStaion=s.s_id inner join station st on st.s_id=ts.toStation where startDate='2024-01-10' group by t.t_id

select t_id from TrainSchedule ts inner join train t on ts.ts_trainId=t.t_id inner join station s on ts.fromStaion=s.s_id inner join station st on st.s_id=ts.toStation where startDate='2024-01-10' group by t.t_id

select * from TrainSchedule

select * from StationDistance

insert into StationDistance values
(1,2,100),
(2,3,200),
(3,4,300)

--According to name

--DECLARE @FromDate DATE = '2024-01-10';
--DECLARE @FromStationName VARCHAR(255) = 'A';
--DECLARE @ToStationName VARCHAR(255) = 'C';

--SELECT
--    train.t_name AS TrainName,
--    fromStation.s_name AS FromStation,
--    toStation.s_name AS ToStation,
--    TrainSchedule.arrivalTime,
--    TrainSchedule.departureTime,
--    TrainSchedule.startDate
--FROM
--    TrainSchedule
--INNER JOIN train ON TrainSchedule.ts_trainId = train.t_id
--INNER JOIN station AS fromStation ON TrainSchedule.fromStaion = fromStation.s_id
--INNER JOIN station AS toStation ON TrainSchedule.toStation = toStation.s_id
--WHERE
--    fromStation.s_name = @FromStationName
--    AND toStation.s_name = @ToStationName
--    AND TrainSchedule.startDate = @FromDate;

--According to Id--

--DECLARE @startDate DATE = '2024-01-10';
--DECLARE @FromStationID INT = 1; -- Replace with the actual stationID for station A
--DECLARE @ToStationID INT = 3;   -- Replace with the actual stationID for station C

--SELECT
--    train.t_name AS TrainName,
--    fromStation.s_name AS FromStation,
--    toStation.s_name AS ToStation,
--    TrainSchedule.arrivalTime,
--    TrainSchedule.departureTime,
--    TrainSchedule.startDate
--FROM
--    TrainSchedule
--INNER JOIN train ON TrainSchedule.ts_trainId = train.t_id
--INNER JOIN station AS fromStation ON TrainSchedule.fromStaion = fromStation.s_id
--INNER JOIN station AS toStation ON TrainSchedule.toStation = toStation.s_id
--WHERE
--    fromStation.s_id = @FromStationID
--    AND toStation.s_id = @ToStationID
--    AND TrainSchedule.startDate = @startDate;

--DECLARE @date DATE = '2024-01-10'; -- Replace with the actual date
--DECLARE @fromStationId INT = 1; -- Replace with the actual source station ID
--DECLARE @toStationId INT = 4; -- Replace with the actual destination station ID

---- Query to find the train traveling on the specified route on the given date with distance
--SELECT
--    TrainRoute.RouteId,
--    Train.t_name AS TrainName,
--    TrainRoute.StopOrder,
--    TrainRoute.ArrivalTime,
--    TrainRoute.DepartureTime,
--    StationDistance.Distance
--FROM
--    TrainRoute
--JOIN
--    Train ON TrainRoute.TrainId = Train.t_id
--JOIN
--    TrainSchedule ON TrainSchedule.ts_trainId = Train.t_id
--JOIN
--    StationDistance ON
--        StationDistance.FromStationId = TrainSchedule.fromStaion
--        AND StationDistance.ToStationId = TrainSchedule.toStation
--WHERE
--    TrainSchedule.startDate = @date
--    AND TrainSchedule.fromStaion = @fromStationId
--    AND TrainSchedule.toStation = @toStationId;

--DECLARE @date DATE = '2024-01-10'; -- Replace with the actual date
--DECLARE @fromStationId INT = 2; -- Replace with the actual source station ID
--DECLARE @toStationId INT = 4; -- Replace with the actual destination station ID

---- Query to find the train traveling from Station 2 to Station 4 on the specified date
--SELECT
--    TrainRoute.RouteId,
--    Train.t_name AS TrainName,
--    TrainRoute.StopOrder,
--    TrainRoute.ArrivalTime,
--    TrainRoute.DepartureTime,
--    StationDistance.Distance
--FROM
--    TrainRoute
--JOIN
--    Train ON TrainRoute.TrainId = Train.t_id
--JOIN
--    TrainSchedule ON TrainSchedule.ts_trainId = Train.t_id
--JOIN
--    StationDistance ON
--        StationDistance.FromStationId = TrainSchedule.fromStaion
--        AND StationDistance.ToStationId = TrainSchedule.toStation
--WHERE
--    TrainSchedule.startDate = @date
--    AND TrainSchedule.fromStaion = @fromStationId
--    AND TrainSchedule.toStation = @toStationId;

	select * from TrainSchedule ts inner join train t on ts.ts_trainId=t.t_id inner join station s on ts.fromStaion=s.s_id inner join station st on st.s_id=ts.toStation where startDate='2024-01-10' and s.s_id=1 and st.s_id=3

	select * from TrainSchedule ts inner join train t on ts.ts_trainId=t.t_id inner join station s on ts.fromStaion=s.s_id inner join station st on st.s_id=ts.toStation where startDate='2024-01-10'


DECLARE @trainId INT = 1; -- Replace with the actual train ID
DECLARE @fromStationId INT = 1; -- Replace with the actual source station ID (A)
DECLARE @toStationId INT = 3; -- Replace with the actual destination station ID (J)

-- Calculate the total distance for the train route
SELECT
    SUM(sd.Distance) AS TotalDistance
FROM
    TrainRoute tr
JOIN
    StationDistance sd ON tr.StationId = sd.FromStationId AND tr.StopOrder < (SELECT StopOrder FROM TrainRoute WHERE TrainId = @trainId AND StationId = @toStationId)
WHERE
    tr.TrainId = @trainId
    AND tr.StationId >= @fromStationId
    AND tr.StationId <= @toStationId;
