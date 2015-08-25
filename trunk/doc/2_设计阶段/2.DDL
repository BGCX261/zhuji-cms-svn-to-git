/*    此 SQL DDL 脚本由 Microsoft Visual Studio (发布日期:LOCAL BUILD) 生成。                            */

/*    所用驱动程序: Microsoft Visual Studio － Microsoft SQL Server 驱动程序。                            */
/*    文档: F:\zj\project\cms\doc\2_设计阶段\2.3 数据库模型.vsd。                                         */
/*    创建时间: 2008年1月11日 22:58。                                                                 */
/*    操作: 来自 Visio 更新数据库向导。                                                                   */
/*    已连接的数据源: cms                                                                            */
/*    已连接的服务器: 449780209C474B3                                                                */
/*    已连接的数据库: cms                                                                            */



SET QUOTED_IDENTIFIER ON

go


/* 从表 "dbo"."Review" 中删除主键约束、唯一索引约束和非唯一索引约束。                                                  */
alter table "dbo"."Review" drop constraint "Comment_PK"  


go

/* 为表 "dbo"."Review" 添加剩余的键、约束和索引。                                                            */
alter table "dbo"."Review"
	add constraint "Review_PK" primary key clustered ("Id")   


go


/* 这是 Microsoft Visual Studio 生成的 SQL DDL 脚本的末尾。                                              */
