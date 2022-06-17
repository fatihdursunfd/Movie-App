import React , { useEffect , useState } from 'react'
import Box from '@mui/material/Box';
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import SearchTwoToneIcon from '@mui/icons-material/SearchTwoTone';
import TrendingUpOutlinedIcon from '@mui/icons-material/TrendingUpOutlined';
import MovieFilterSharpIcon from '@mui/icons-material/MovieFilterSharp';
import LiveTvSharpIcon from '@mui/icons-material/LiveTvSharp';
import {useNavigate} from 'react-router-dom'

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
        <Box sx={{ width: 500 }} style = {{width:"100%" , position:"fixed" , bottom:0 , zIndex:100 }}>
            <BottomNavigation
                showLabels
                value={value}
                onChange={(event, newValue) => {
                    setValue(newValue);
                }}>
                <BottomNavigationAction style={{ color: "#151D3B" }} label="Trendings" icon={<TrendingUpOutlinedIcon />} />
                <BottomNavigationAction style={{ color: "#151D3B" }} label="Moives" icon={<MovieFilterSharpIcon />} /> 
                <BottomNavigationAction style={{ color: "#151D3B" }} label="Series" icon={<LiveTvSharpIcon />} />
                <BottomNavigationAction style={{ color: "#151D3B" }} label="Search" icon={<SearchTwoToneIcon />} />
            </BottomNavigation>
        </Box>
    )
}
export default MainNav