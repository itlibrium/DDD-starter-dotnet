using System.Reflection;
using P3Model.Annotations.Technology;

[assembly: Layer("Process Model")]

namespace MyCompany.ECommerce.RiskManagement;

public class RiskManagementProcessModelLayerInfo
{
    public static Assembly Assembly => typeof(RiskManagementProcessModelLayerInfo).Assembly;
}