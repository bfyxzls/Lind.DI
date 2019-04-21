# Lind.DI的意义
改善Ioc注入的方式，主要是借鉴了java spring框架，觉得它的注释方式实现的IOC注入是比较方便的。

# Lind.DI主要依赖的项目
* Autofac
* Autofac.Extras.DynamicProxy

# 特性（attribute）的介绍
* Component	添加在类上，这个类会被注册到IOC容器里
* Injection	添加在字段上，这个字段会从IOC容器里注入对应的实例

# 对象的生命周期
* CurrentScope
* CurrentRequest
* Global

# Lind.DI使用
* 全局注册所有组件        DIFactory.Init();
* 拦截当前对象，并注入    DIFactory.InjectFromObject(this)

