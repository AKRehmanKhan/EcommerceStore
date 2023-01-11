create database dbproject
use  dbproject


create table discount_Coupons(
	id int not null primary key,
	_percentage decimal(4,2)
)

create  table Categorey(
    Id int not null primary key,
	namec varchar(20) ,
)

create table brand(
	ID int not null primary key,
	_name varchar(10),
	total_items int
)

create   table product_info(
	ID int not null primary key,
	namep varchar(20) not null,
	cid int foreign key references Categorey(Id) on update cascade on delete cascade ,
	brandid int foreign key references brand(ID) on update cascade on delete cascade,
	price int,
	_image varchar(max)
)

create table DicountedItems
(
 pid int foreign key references product_info (ID) on update cascade on delete cascade,
 did int foreign key references discount_Coupons(id) on update cascade on delete cascade
 primary key (pid)

)

create   table laptop(
    pid int foreign key references product_info(ID) on update cascade on delete cascade,
	Laptop_ID varchar(30) primary key not null,
	Laptop_Name varchar(30) ,
	Generation varchar(30) ,
	Brand varchar(30) ,
	Proceesor varchar(30) ,
	RAM varchar(30) ,
	HDD varchar(30) ,
	SSD varchar(30) ,
	Stock varchar(30) ,
	Price int ,
	Laptop_Pic varchar(60), 
)

create table ssd(
    pid int foreign key references product_info(ID) on update cascade on delete cascade,
	SSD_ID  varchar(30) primary key not null,
    Brand  varchar(30) ,
	Size varchar(20),
	Price  int,
	Stock varchar(30) ,
	SSD_Pic varchar(60), 
)

create table ram(
    pid int foreign key references product_info(ID) on update cascade on delete cascade,
	RAM_ID  varchar(30) primary key not null,
    Brand  varchar(30) ,
	Size varchar(20),
	Price  int,
	Stock varchar(30) ,
	DDR_Version int check (ddr_version between 1 and 5),
	RAM_Pic varchar(60), 
)


create table sellers(
	login_id varchar(20) not null primary key ,
	_password varchar(10),
	full_name varchar(25),
	dob  date,
	city varchar(20),
	gender varchar(20),
	email varchar(40),
	_address varchar(50),
	phone_number varchar(20),
	--phone_number bigint check (phone_number between 10000000000 and 99999999999),
)



create table customer(
	login_id varchar(20) not null primary key,
	_password varchar(10),
	full_name varchar(25),
	dob  date,
	city varchar(20),
	gender varchar(20),
	email varchar(40),
	_address varchar(50),
	phone_number varchar(20),
	--phone_number bigint check (phone_number between 10000000000 and 99999999999),
)


create  table inventory(
	sellerID varchar(20) foreign key references sellers(login_id)on update cascade on delete cascade ,
	productID int foreign key references product_info(ID) on update cascade on delete cascade,
	stock int
)


create  table transactions(
  ID int not null primary key,
  customerID varchar(20) foreign key references customer(login_id) ,
  quantity int,
  payment  int,
  _dateTime DateTime
)

create table sold_items(
	transactionID int foreign key references transactions(ID) ,
	customerID varchar(20) foreign key references customer(login_id),
	sellerID varchar(20)  foreign key references sellers(login_id),
	productID int foreign key references product_info(ID) ,
	quantity int 
)


create table cart(
	customerID varchar(20) foreign key references customer(login_id) on update cascade on delete cascade,
	productID int foreign key references product_info(ID) on update cascade on delete cascade,
	quantity int,
    )
	
create table feedback(
	ID int not null primary key,
	customerID varchar(20) foreign key references customer(login_id) on update cascade on delete cascade,
	productID int foreign key references product_info(ID)  on update cascade on delete cascade,
	feedbackDate date,
	fdescrip  varchar(20),
	rating int check (rating between 1 and 5)
)


create table admin_(
	login_id varchar(20) not null primary key,
	_password varchar(15),
	full_name varchar(20),
)

go
create view OrderDetails as
select s.transactionID as Transacation_ID,s.customerID as Customer_ID,s.sellerID as Seller_ID,s.productID as Product_ID, s.quantity as Quantity,t.payment*s.quantity as Price ,t._dateTime as Date_Time
from  sold_items as s join transactions as t on t.ID=s.transactionID
go

go
create view ProductDeatils as
select p.ID as Product_ID , p.namep as Product_Name ,(select b._name from brand as b where b.ID=p.brandid) as Brand,p.price as Price,i.stock as Stock , i.sellerID as Seller_Id
from product_info as  p join inventory as i on i.productID=p.ID
go


--procedures

--1
go
create  procedure AddToinventory
@Laptop_ID varchar(30),
@Laptop_Name varchar(30),
@Stock varchar(30),
@Generation varchar(30),
@Brand varchar(30),
@Proceesor varchar(30),
@RAM varchar(30),
@HDD varchar(30),
@SSD varchar(30),
@Price int,
@Laptop_Pic varchar(60),
@sellerID varchar(20)
as 
begin

Declare  @pid int
 
   Declare @temp int

    Select @temp = max(ID)
    from product_info
	if(@temp is NULL)
	begin
	  set @pid=0;
	end

 else
	 begin
	 Select @pid= max(ID)
     from product_info 
	 end


 Declare @bi int
 select @bi=ID
 from brand
 where _name=@Brand

 Declare @c int
 set @c=1
 insert into product_info(ID, namep, cid , brandid, price , _image)  values(@pid+1,@Laptop_Name,@c,@bi,@Price,@Laptop_Pic)

 
 insert into inventory(sellerID,productID,stock) values(@sellerID,@pid+1,@Stock)




 insert into laptop(pid,Laptop_ID ,Laptop_Name,Generation,Brand ,Proceesor ,RAM,HDD ,SSD,Stock ,Price ,Laptop_Pic )
 values(@pid+1,@Laptop_ID,@Laptop_Name,@Generation,@Brand,@Proceesor,@RAM,@HDD,@SSD,@Stock,@Price,@Laptop_Pic)




end
go

-- add to ssd
go
create  procedure addssdtoinventory
@SSD_ID varchar(30),
@Size varchar(20),
@Brand varchar(30),
@Price  int,
@Stock  varchar(30),
@SSD_Pic varchar(60),
@sellerID varchar(20)
as 
begin

Declare  @pid int
Declare @temp int
    Select @temp = max(ID)
    from product_info
	if(@temp is NULL)
	begin
	  set @pid=0;
	end

 else
	 begin
	 Select @pid= max(ID)
     from product_info 
	 end
   

 Declare @bi int
 select @bi=ID
 from brand
 where _name=@Brand

 Declare @c int
 set @c=3
 insert into product_info(ID, namep, cid , brandid, price , _image)  values(@pid+1,'SSD',@c,@bi,@Price,@SSD_Pic)

 insert into inventory(sellerID,productID,stock) values(@sellerID,@pid+1,@Stock)

  insert into ssd(pid,SSD_ID ,Brand,Size,Price ,Stock,SSD_Pic) values(@pid+1,@SSD_ID ,@Brand,@Size ,@Price ,@Stock,@SSD_Pic)

end
go


-- add to ram
go
create  procedure addramtoinventory
@RAM_ID varchar(30),
@Stock varchar(20),
@DDR_Version varchar(30),
@Brand  varchar(30),
@Size  varchar(30),
@Price  int,
@RAM_Pic varchar(60),
@sellerID varchar(20)
as 
begin

Declare   @pid int
Declare @temp int
    Select @temp = max(ID)
    from product_info
	if(@temp is NULL)
	begin
	  set @pid=0;
	end

 else
	 begin
	 Select @pid= max(ID)
     from product_info 
	 end
   

 Declare @bi int
 select @bi=ID
 from brand
 where _name=@Brand

 Declare @c int
 set @c=2
 insert into product_info(ID, namep, cid , brandid, price , _image)  values(@pid+1,'RAM',@c,@bi,@Price,@RAM_Pic)

 insert into inventory(sellerID,productID,stock) values(@sellerID,@pid+1,@Stock)

  insert into ram(pid,RAM_ID ,Brand,Size,Price,DDR_Version,Stock,RAM_Pic) values(@pid+1,@RAM_ID ,@Brand,@Size ,@Price ,@DDR_Version,@Stock,@RAM_Pic)

end
go

---product deletion
delete from laptop
delete from ram
delete from ssd
delete from product_info
delete from inventory
delete  from product_info  where cid <4
select * delete  from sold_items

go
create procedure showproductdetails
@ID int
as
begin

Declare @temp int

select @temp =cid
from product_info
where ID=@ID

if(@temp=1)
begin
select * from laptop
end

else if (@temp=2)
begin
select * from ram
end

else if (@temp=3)
begin
select * from ssd
end

end
go


--productdetails
create procedure productdetails
@pid  int,
@cid int output
as
begin

select @cid=p.cid
from product_info  as p
where ID=@pid

if @cid=1
begin
   select * from laptop as l where l.pid=@pid
   return @cid
end

else if @cid=3
begin
   select * from ssd as s where s.pid=@pid
   return @cid
end 

else if @cid=2
begin
   select * from ram as r where r.pid=@pid
   return @cid
end

end



   --View CArt
go
create procedure ViewCart
@uid varchar(20),
@total int output
as
begin

 
   begin
   Select p.ID as Product_ID ,p.namep as Product_Name,p.price as PRice,q.quantity as Quantity,(p.price*q.quantity) as Total
   from product_info as p join (
   select  p.ID , count(*) as quantity from cart as c join product_info as p on c.productID = p.ID  join Brand as b on p.brandid = b.ID where c.customerID=@uid  group by p.ID
    ) as q on  p.ID=q.ID

 
  end

  begin
  if  not exists(select *
  from cart where 
  customerID=@uid)
  begin
    set @total=0;
	return @total
  end

  else
   select @total=sum(p.price*c.quantity)
   from cart as c join product_info as p on c.productID=p.ID
   where c.customerID=@uid
   return @total
   end
end
go


Declare @total int
execute  ViewCart'11',@total  out 
select @total





--Add to cartt
go
create procedure insertintocart
@pid int,
@cid varchar(20),
@sf int out
as
begin

declare @ccid int
select @ccid=p.cid
from  product_info as p
where ID=@pid

Declare @s int

if(@ccid)=1
begin

select @s=Stock
from laptop as l
where l.pid=@pid

if @s<1
begin
  set @sf=0
  return @sf
end

else
begin
insert into cart(customerID,productID,quantity) values(@cid,@pid,1)
  set @sf=1
  return @sf
end
end

else if (@ccid)=2
begin
select @s=Stock
from ram as r
where r.pid=@pid

if @s<1
begin
  set @sf=0
  return @sf
end

else
begin
insert into cart(customerID,productID,quantity) values(@cid,@pid,1)
  set @sf=1
  return @sf
end
end

else if (@ccid)=3
begin
select @s=Stock
from ssd as s
where s.pid=@pid

if @s<1
begin
  set @sf=0
  return @sf
end

else
begin
insert into cart(customerID,productID,quantity) values(@cid,@pid,1)
  set @sf=1
  return @sf
end
end
return @sf
end
go

--Declare @re int
--execute insertintocart 2,'abd', @re out
--select @re




create  procedure Buy
@cid varchar(20),
@tid int out
as
begin
Declare @temp int
    Select @temp = max(ID)
    from transactions
	if(@temp is NULL)
	begin
	  set @temp=1;
	end

 else
	 begin
	 Select @temp= max(ID)+1
     from transactions 
	 end
	 
	 Insert into transactions(ID,customerID) values (@temp,@cid)
	 set @tid=@temp
	 return @tid
	 end 
	 go

--Declare @t int
--execute Buy 'abd', @t out
--select @t



--Stock Chck for buy
go
create procedure canbuy
@pid int,
@qua int,
@lf int out ,
@rf int out ,
@sf int out
as
begin

set @lf=0
set @rf =0
set @sf =0

declare @ccid int
select @ccid=p.cid
from  product_info as p
where ID=@pid

Declare @s int

if(@ccid)=1
begin

select @s=Stock
from laptop as l
where l.pid=@pid

if @s<@qua
begin
  set @lf=0
  return @lf
end

else
begin
  set @lf=1
  return @lf
end
end

else if (@ccid)=2
begin
select @s=Stock
from ram as r
where r.pid=@pid

if @s<@qua
begin
  set @rf=0
  return @rf
end

else
begin
  set @rf=1
  return @rf
end
end

else if (@ccid)=3
begin
select @s=Stock
from ssd as s
where s.pid=@pid

if @s<@qua
begin
  set @sf=0
  return @sf
end

else
begin
  set @sf=1
  return @sf
end
end
return @sf
end
go

--Declare @l int , @r int , @s int
--execute canbuy 3,2,@l out ,@r out ,@s out
--select @l as l,@r as r,@s as s
                      
	
go
create procedure removebuyproducts
@pid int,
@qua int ,
@uid varchar(20)
as 
begin

declare @ccid int
select @ccid=p.cid
from  product_info as p
where ID=@pid

Declare @s int
Declare  @sto int
select @sto=Stock from inventory where productID=@pid

if(@sto)>=@qua
begin
update inventory set stock-=@qua where productID=@pid
delete from cart where  customerID=@uid
end
else
begin
return
end

if(@ccid)=1
begin
select @s=Stock
from laptop as l
where l.pid=@pid

if @s>=@qua
begin
update laptop set Stock -=@qua where pid=@pid
end

end

else if (@ccid)=2
begin
select @s=Stock
from ram as r
where r.pid=@pid


if @s>=@qua
begin
update ram set Stock -=@qua where pid=@pid
end

end

else if (@ccid)=3
begin

select @s=Stock
from ssd as s
where s.pid=@pid

if @s>=@qua
begin
update ssd set Stock -=@qua where pid=@pid
end
end


end
go

--Declare @uid int
--execute removebuyproducts 1,1,@uid
--select @uid



--necessary inserts
insert into brand(ID,_name ,total_items) values (1,'DELL',5);
insert into brand(ID,_name ,total_items) values (2,'Apple',5);
insert into brand(ID,_name ,total_items) values (3,'HP',5);

insert into brand(ID,_name ,total_items) values (4,'Kingston',5);
insert into brand(ID,_name ,total_items) values (5,'Hikvision',5);
insert into brand(ID,_name ,total_items) values (6,'Kingfast',5);



insert into Categorey(Id,namec) values(1,'laptop');
insert into Categorey(Id,namec) values(2,'RAM');
insert into Categorey(Id,namec) values(3,'SSD');

insert into admin_(login_id,_password,full_name) values ('123a','123a','Hamza')

go
create procedure feedbackP
@pid int,
@rating int ,
@cid varchar(20),
@decr varchar(50)
as
begin
Declare @temp int
    Select @temp = max(ID)
    from feedback
	if(@temp is NULL)
	begin
	  set @temp=1;
	end

 else
	 begin
	 Select @temp= max(ID)+1
     from feedback 
	 end

	 insert into feedback (ID,customerID,productID,fdescrip,feedbackDate,rating)
	 values(@temp,@cid,@pid,@decr,getdate(),@rating)
end
go



select *from transactions 
select *from sold_items
select * from cart
select * from product_info

select * from Categorey
select * from brand
select *  from laptop
select *  from ssd
select *  from ram
select * from inventory
select * from customer
select * from sellers

select p.namep, p.ID , p.price,b._name , p._image, i.Stock 
from product_info  as p join brand as b on p.brandid =  b.ID  join inventory as i on p.ID=i.productID 

  
--delete from sold_items
--delete from inventory 
--delete from laptop
--delete from ram
--delete from ssd
--delete from sold_items
--delete from transactions
--delete from cart
--delete from  product_info
