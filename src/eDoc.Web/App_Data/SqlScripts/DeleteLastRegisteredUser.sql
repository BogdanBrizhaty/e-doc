declare @lastAspNetUser varchar(128);

select top 1  @lastAspNetUser = Id from AspNetUsers order by CreationDate desc

-- delete patient
delete from Patients where UserPersonalInfoId = @lastAspNetUser
-- delete doctor
delete from Doctors where UserPersonalInfoId = @lastAspNetUser

-- delete personal info
delete from UserPersonalInfoes where Id = @lastAspNetUser

-- from app users

delete from AspNetUsers where Id = @lastAspNetUser
