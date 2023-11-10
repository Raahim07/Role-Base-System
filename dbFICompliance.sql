use dbFIComp;

Select * from tblUsers;
Select * from tblRoles;
Select * from tblMenus;
Select * from tblRolesMenus; 

Delete from tblUsers where UserID=101;

Update tblRolesMenus set RoleID=2 where MenuRoleID=4;


 Insert   into tblRolesMenus  values IsAllowed (2,1);
Delete from tblUsers where UserId=104;

update tblmenus set menuname='Add User' where menuid=1

