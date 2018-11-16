
-- Check IsPermissionInUserRoles
SELECT * FROM (
SELECT U.UserName,
	   UR.UserRoleId,
	   R.IsSysAdmin
FROM MainProduct.[User] U
JOIN MainProduct.UserRole UR
ON U.Id = UR.UserId
JOIN MainProduct.[Role] R
ON UR.RoleId = R.Id
WHERE U.Id ='428b5c58-d43c-4595-bdc3-00d148b61ebc' //IsUserRoleInRole
) A
JOIN (
SELECT UR.UserRoleId,
	   P.DisplayName
FROM MainProduct.UserRole UR
JOIN [Permissions] P
ON P.UserRoleId = UR.UserRoleId
WHERE P.Name ='FootballGround.UserManger' //IsPermissionRole
) B
ON A.UserRoleId = B.UserRoleId


--CREATE NONCLUSTERED INDEX IX_User_Id   
--ON MainProduct.[User] (Id)

--CREATE NONCLUSTERED INDEX IX_Role_Id   
--ON MainProduct.[Role] (Id)



CREATE NONCLUSTERED INDEX IX_Permissions_Id
ON [Permissions] (Id)

DROP INDEX IX_User_Id   
    ON MainProduct.[UserRole];  
GO  

select * from MainProduct.[User] p where p.Id=1

