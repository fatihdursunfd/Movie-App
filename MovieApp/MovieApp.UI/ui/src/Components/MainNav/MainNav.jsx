import React , { useEffect , useState , useContext } from 'react'
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import SearchTwoToneIcon from '@mui/icons-material/SearchTwoTone';
import TrendingUpOutlinedIcon from '@mui/icons-material/TrendingUpOutlined';
import MovieFilterSharpIcon from '@mui/icons-material/MovieFilterSharp';
import LiveTvSharpIcon from '@mui/icons-material/LiveTvSharp';
import LoginIcon from '@mui/icons-material/Login';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import LogoutIcon from '@mui/icons-material/Logout';
import {useNavigate} from 'react-router-dom'
import { Box ,ThemeProvider, createTheme } from '@mui/system';
import {Link} from "react-router-dom";
import Login from '@mui/icons-material/Login';
import {Context} from "../../Context/Context"

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

    const { user } = useContext(Context);
      
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
                
                {
                    user &&
                    <div>
                        <Link to="/profile">
                            <BottomNavigationAction label="Search" icon={<AccountCircleIcon />} />
                        </Link>
                        <Link to="/logout">
                            <BottomNavigationAction label="Search" icon={<LogoutIcon />} />
                        </Link>
                    </div>
                }
                {   
                    !user &&
                    <Link to="/login">
                        <BottomNavigationAction label="Login" icon={<LoginIcon />} />
                    </Link>
                }
                
            </BottomNavigation>
        </Box>
    )
}
export default MainNav