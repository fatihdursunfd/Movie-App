import React from 'react'
import Pagination from '@mui/material/Pagination';
import { createTheme , ThemeProvider } from '@mui/material/styles';
import { green, purple } from '@mui/material/colors';

const theme = createTheme({
  palette: {
    primary: {
      main: purple[500],
    },
    secondary: {
      main: green[500],
    },
  },
});

const CustomPagination = ({ setPage, numOfPages = 10 }) => {
  const handlePageChange = (page) => {
    setPage(page);
    window.scroll(0, 0);
};

  return (
    <div style={{ width: "100%", display: "flex", justifyContent: "center", marginTop: 25, }}>
        <ThemeProvider theme={theme}>
            <Pagination 
                count={numOfPages} 
                onChange = {(e) => handlePageChange(e.target.textContent)} 
                hideNextButton hidePrevButton color="primary"
            />
        </ThemeProvider>
    </div>
  )
}
export default CustomPagination