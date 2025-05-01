
import { BrowserRouter, Route, Routes } from 'react-router-dom'

import LoginPage from './pages/login/Index'
import DashboardPage from './pages/dashboard/Index'

function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<LoginPage />}></Route>

        <Route path='/dashboard' element={<DashboardPage />}></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
