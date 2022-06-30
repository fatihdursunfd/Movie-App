import './App.css';
import Header from './Components/Header/Header';
import Movies from "./Pages/Movies/Movies"
import Series from "./Pages/Series/Series"
import Search  from "./Pages/Search/Search";
import TopRated from "./Pages/TopRated/TopRated"
import MovieDetail from './Pages/MovieDetail/MovieDetail';
import Login from "./Pages/Login/Login"
import Logout from "./Pages/Logout/Logout"
import Register from "./Pages/Register/Register"
import Container from '@mui/material/Container';
import Profile from "./Pages/Profile/Profile"
import MainNav from './Components/MainNav/MainNav';
import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";

function App() {

    return (
      <BrowserRouter >
        <Header />
        <div className="app">
          <Container>
            <Routes>
                <Route exact path="/" element={ <TopRated />}  />
                <Route path="movies" element={ <Movies />} />
                <Route path="series" element={ <Series />} />
                <Route path="search" element={ <Search />} />
                <Route path="login" element={ <Login />} />
                <Route path="logout" element={ <Logout />} />
                <Route path="register" element={ <Register />} />
                <Route path="profile" element={ <Profile />} />
                <Route path="/detail/:mediaType/:id" element={ <MovieDetail />} />
            </Routes>
          </Container>
        </div>
        <MainNav />
      </BrowserRouter>
    );
}
export default App;
