import React from 'react'
import TextField from '@mui/material/TextField';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Button from '@mui/material/Button';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { useEffect, useState } from "react";
import axios from "axios";
import CustomPagination from "../../Components/Pagination/CustomPagination";
import Single from "../../Components/Single/Single";
import SearchIcon from '@mui/icons-material/Search';
import Constants from '../../Utilities/Constants';
import "./Search.css"
import "../TopRated/TopRated.css"

const Search = () => {
  const [type, setType] = useState(0);
  const [searchText, setSearchText] = useState("");
  const [page, setPage] = useState(1);
  const [numOfPages, setNumOfPages] = useState();
  const [movies , setMovies] = useState([])

  const darkTheme = createTheme({
    palette: {
      primary: {
        main: "#EEEEEE",
      },
    },
  });

  const fetchSearch = async () => {
      if( searchText !== "" && searchText !== null) {
        const url = Constants.API_URL_GET_MOVIE_BY_NAME + searchText
        await axios.get(url)
                    .then((response) => {
                      if(response.data.error ===  null){
                          setMovies(response.data.data)
                    }
                  })
      }
  };

  useEffect(() => {
    window.scroll(0, 0);
    fetchSearch();
  }, [type, page]);


  return (
    <div>
      <ThemeProvider theme={darkTheme}>
        <div className="search">
            <TextField 
                style={{ flex: 1 }}
                label="Search"
                variant="filled"
                onChange={(e) => setSearchText(e.target.value)}
            />
            <Button onClick={fetchSearch} variant="contained" style={{ marginLeft: 10 }} >
              <SearchIcon fontSize="large" />
            </Button>
        </div>
        <Tabs 
            value={type} 
            indicatorColor="primary"
            textColor="primary"
            onChange={(event, newValue) => {
              setType(newValue);
              setPage(1);
            }}
            style={{ paddingBottom: 5 }}
            aria-label="disabled tabs example"
        >
          <Tab style={{ width: "50%" }} label="Search Movies" />
          <Tab style={{ width: "50%" }} label="Search TV Series" />
        </Tabs>
      </ThemeProvider>

      <div className="trending"> {
          movies && movies.map((c) => (
            <Single
                key={c.movieID}
                id={c.movieID}
                poster={c.imageLgUrl}
                title={c.name}
                date={c.date }
                media_type={"tv"}
                vote_average={c.rating}
            /> 
          ))}
          {
              searchText && !movies && (type ? <h2>No Series Found</h2> : <h2>No Movies Found</h2>)
          }
      </div>
      {
        numOfPages > 1 && ( <CustomPagination setPage={setPage} numOfPages={numOfPages} />)
      }
    </div>
  )
}

export default Search