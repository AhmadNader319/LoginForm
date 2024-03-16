import  New  from "./components/New";
import  Home  from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/new',
    element: <New />
  }
];

export default AppRoutes;
