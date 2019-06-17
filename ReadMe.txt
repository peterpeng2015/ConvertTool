约定大于配置
1.ConvertTool项目Config文件夹下.config文件命名规范
文件命名规范=源数据库类型+"2"+目标数据库类型+".config"

2.ConvertToolCore项目Creator文件下对应的数据库下的.cs文件命名规范
文件命名规范=目标数据库类型+请求数据类型+"Creator.cs"

3.DBHelper项目数据库下.cs文件命名规范
文件命名规范=请求数据库类型+"Helper.cs"

4.ConvertToolCore项目下CreatorFactory根据目标数据库类型与请求数据类型获取对应的生成对象

5.DBHelper项目下DBHelperFactory根据请求数据库类型与数据库连接字符串获取对应的数据库对象

6.ConvertTool项目Config文件夹下.config中的配置项字段也有一定的顺序与命名规则，要根据实际情况结合Creator进行修改