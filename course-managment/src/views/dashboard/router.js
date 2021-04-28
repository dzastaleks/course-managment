import DashboardLayout from "@/layouts/DashboardLayout";
import EmptyLayout from"@/layouts/EmptyLayout";
import DashboardIndex from "./index/Index";
import Course from "./courses/Index";
import Student from "./students/Index";
import Year from "./years/Index";
import CourseForm from "./courses/Form";
import StudentForm from "./students/Form";
import YearForm from "./years/Form";
import CourseDetails from "./courses/Details";
import StudentDetails from "./students/Details";
import AddStudents from "./courses/Add";
import DeleteStudents from "./courses/Delete";

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
        component: EmptyLayout,
        meta: { componentName: "menu.menu_item_dashboard" },
        children: [
            {
                path:"index",
                name:"Course",
                component: Course
            },
            {
                path:"create",
                name:"CourseCreate",
                component:CourseForm
            },
            {
                path:"edit/:pkCourseId",
                name:"CourseEdit",
                component:CourseForm
            },
            {
                path:"details/:pkCourseId",
                name:"CourseDetails",
                component:CourseDetails
            },
            {
              path:"add/:pkCourseId",
              name:"AddStudents",
              component:AddStudents
            },
            {
              path:"delete/:pkCourseId",
              name:"DeleteStudents",
              component:DeleteStudents
          }
        ]
      },
      {
        path: "student",
        name: "Student",
        component: EmptyLayout,
        meta: { componentName: "menu.menu_item_dashboard" },
        children: [ {
            path:"index",
            name:"Student",
            component: Student
        },
        {
            path:"create",
            name:"StudentCreate",
            component:StudentForm
        },
        {
            path:"edit/:pkStudentID",
            name:"StudentEdit",
            component:StudentForm
        },
        {
            path:"details/:pkStudentID",
            name:"StudentDetails",
            component:StudentDetails
        }
      ]
      },
      {
        path: "year",
        name: "Year",
        component: EmptyLayout,
        meta: { componentName: "menu.menu_item_dashboard" },
        children:[
            {
                path:"index",
                name:"Year",
                component: Year
            },
            {
                path:"create",
                name:"YearCreate",
                component:YearForm
            },
            {
                path:"edit/:yearId",
                name:"YearEdit",
                component:YearForm
            }
        ]
      },
    ]
  },
];

export default router;
