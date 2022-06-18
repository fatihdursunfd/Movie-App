import './App.css';
import Header from './Components/Header/Header';
import Movies from "./Pages/Movies/Movies"
import Series from "./Pages/Series/Series"
import Search  from "./Pages/Search/Search";
import Trending from "./Pages/Trending/Trending"
import MovieDetail from './Pages/MovieDetail/MovieDetail';
import Container from '@mui/material/Container';
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
            <Route exact path="/" element={ <Trending />}  />
            <Route path="movies" element={ <Movies />} />
            <Route path="series" element={ <Series />} />
            <Route path="search" element={ <Search />} />
            <Route path="/detail/:mediaType/:id" element={ <MovieDetail />} />
          </Routes>
        </Container>
      </div>
      <MainNav />
    </BrowserRouter>
  );
}
export default App;
