using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<BasketDetailManager>().As<IBasketDetailService>();
            builder.RegisterType<EfBasketDetailDal>().As<IBasketDetailDal>();

            builder.RegisterType<AppUserManager>().As<IAppUserService>();
            builder.RegisterType<EfAppUserDal>().As<IAppUserDal>();

            builder.RegisterType<KdvManager>().As<IKdvService>();
            builder.RegisterType<EfKdvDal>().As<IKdvDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();

        }
    }
}
