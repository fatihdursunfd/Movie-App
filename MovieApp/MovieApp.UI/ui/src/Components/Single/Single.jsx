import React from 'react'
import {img_300 , unavailable} from "../../config/config"
import "./Single.css"
import Badge from '@mui/material/Badge';
import {Link} from "react-router-dom"

const Single = ({
    id,
    poster,
    title,
    date,
    media_type,
    vote_average,
    }) => {

    return (
        <Link to={`/detail/${media_type}/${id}`} >
            <div className='media'>
                    <Badge badgeContent={vote_average} color={vote_average > 7 ? "primary" : "secondary"} />
                    <img className='poster' src={poster ? `${poster}` : unavailable} alt={title} />
                    <b className='title' >{title}</b>
                    <span className='date'>{date}</span>
            </div>
        </Link>
    )
}
export default Single
