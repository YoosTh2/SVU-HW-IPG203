using RepairCenter.Models;

namespace RepairCenter.Events;

///هاد المفروض بيحدد شكل الدالة الي بستقبل تنبيه التأخير 

publice delegate Void DeviceOverdueHandler(Appliance device);
