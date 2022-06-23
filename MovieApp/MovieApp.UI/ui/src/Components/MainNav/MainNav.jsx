import React , { useEffect , useState } from 'react'
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import SearchTwoToneIcon from '@mui/icons-material/SearchTwoTone';
import TrendingUpOutlinedIcon from '@mui/icons-material/TrendingUpOutlined';
import MovieFilterSharpIcon from '@mui/icons-material/MovieFilterSharp';
import LiveTvSharpIcon from '@mui/icons-material/LiveTvSharp';
import {useNavigate} from 'react-router-dom'
import { Box ,ThemeProvider, createTheme } from '@mui/system';
import {Link} from "react-router-dom";

const theme = createTheme({
    palette: {
      background: {
        paper: '#D3EBCD',
      },
      text: {
        primary: '#173A5E',
        secondary: '#46505A',
      },
      action: {
        active: '#001E3C',
      },
      success: {
        dark: '#009688',
      },
    },
});

const MainNav = () => {
    const [value, setValue] = useState(0);
    let navigate = useNavigate();

    useEffect(() => {
        if (value === 0) {
            navigate("/")
        } 
        else if (value === 1) {
           navigate("/movies")
        } 
        else if (value === 2) {
            navigate("/series")
        } 
        else if (value === 3) {
            navigate("/search")
        }

      }, [value]); 
      
    return (
        <Box style = {{width:"100%" , position:"fixed" , bottom:0 , zIndex:100 }}>
            <BottomNavigation
                showLabels
                value={value}
                onChange={(event, newValue) => {
                    setValue(newValue);
                }}>
                <Link to="/">
                    <BottomNavigationAction label="Trendings" icon={<TrendingUpOutlinedIcon />} />
                </Link>
                <Link to="/movies">
                    <BottomNavigationAction label="Movies" icon={<MovieFilterSharpIcon />} /> 
                </Link>
                <Link to="/series">
                    <BottomNavigationAction label="Series" icon={<LiveTvSharpIcon />} />
                </Link>
                <Link to="/search">
                    <BottomNavigationAction label="Search" icon={<SearchTwoToneIcon />} />
                </Link>

            </BottomNavigation>
        </Box>
    )
}
export default MainNav