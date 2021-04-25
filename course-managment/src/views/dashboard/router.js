import DashboardLayout from "@/layouts/DashboardLayout";
import DashboardIndex from "./index/Index";
import Course from "./courses/Index";
import Student from "./students/Index";
import Year from "./years/Index";


const router = [
  {
    path: "/dashboard",
    component: DashboardLayout,
    children: [
      {
        path: "index",
        name: "DashboardIndex",
        component: DashboardIndex,
        meta: { componentName: "menu.menu_item_dashboard" },
      },
      {
        path: "course",
        name: "Course",
        component: Course,
        meta: { componentName: "menu.menu_item_dashboard" },
      },
      {
        path: "student",
        name: "Student",
        component: Student,
        meta: { componentName: "menu.menu_item_dashboard" },
      },
      {
        path: "year",
        name: "Year",
        component: Year,
        meta: { componentName: "menu.menu_item_dashboard" },
      },
    ]
  },
];

export default router;
