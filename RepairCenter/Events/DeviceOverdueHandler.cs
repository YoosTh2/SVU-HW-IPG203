using RepairCenter.Models;

namespace RepairCenter.Events;

///هاد المفروض بيحدد شكل الدالة الي بستقبل تنبيه التأخير 

public delegate void DeviceOverdueHandler(Appliance device);
