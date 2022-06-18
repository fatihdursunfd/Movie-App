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
  
const Search = () => {
  const [type, setType] = useState(0);
  const [searchText, setSearchText] = useState("");
  const [page, setPage] = useState(1);
  const [content, setContent] = useState([]);
  const [numOfPages, setNumOfPages] = useState();

  const darkTheme = createTheme({
    palette: {
      primary: {
        main: "#EEEEEE",
      },
    },
  });

  const fetchSearch = async () => {
    try {
        const url = `https://api.themoviedb.org/3/search/${type ? "tv" : "movie"}?api_key=44f4b50a7a7b8ece939348ff65ba06f3&language=en-US&query=${searchText}&page=${page}&include_adult=false`
        const { data } = await axios.get();
        setContent(data.results);
        setNumOfPages(data.total_pages);
    } 
    catch (error) { console.error(error); }
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
          content && content.map((c) => (
            <Single
              key={c.id}
              id={c.id}
              poster={c.poster_path}
              title={c.title || c.name}
              date={c.first_air_date || c.release_date}
              media_type={type ? "tv" : "movie"}
              vote_average={c.vote_average}
            /> 
          ))}
          {
              searchText && !content && (type ? <h2>No Series Found</h2> : <h2>No Movies Found</h2>)
          }
      </div>
      {
        numOfPages > 1 && ( <CustomPagination setPage={setPage} numOfPages={numOfPages} />)
      }
    </div>
  )
}

export default Search