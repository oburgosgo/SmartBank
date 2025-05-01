import { Route, Routes } from "react-router-dom";
import LoginPage from "./pages/login/Index";
import DashboardPage from "./pages/dashboard/Index";


const AppRouter = () => {
    return (
        <Routes>
            <Route path='/' element={<LoginPage />}></Route>

            <Route path='/dashboard' element={<DashboardPage />}></Route>
        </Routes >
    );
}

export default AppRouter;