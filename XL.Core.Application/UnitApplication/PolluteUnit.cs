using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.User;

namespace XL.Core.Application.UnitApplication
{
    public class PolluteUnit : Unit
    {
        public IUserRepository _user;

        /// <summary>
        /// 获取当前单元的类型声明。
        /// </summary>
        public Type Type { get; private set; }

        public PolluteUnit(IUserRepository user)
        {
            this._user = user;
        }

        public override void AddParent()
        {
            base.AddParent();


        }

        public override void SaveUnitArchive()
        {
            base.SaveUnitArchive();

            _user.Save();
        }

        public Unit CreateUnit()
        {
            System.Reflection.ConstructorInfo ci = this.Type.GetConstructor(new System.Type[] { });
            object objInstance = ci.Invoke(new object[] { });

            Unit unit = objInstance as Unit;
            return unit;
        }
    }
}
